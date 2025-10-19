using DataLayer;
using Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLayer
{
    public static class PasswordHasher
    {
        // إعدادات آمنة معقولة
        private const int SaltSize = 16;      // 16 bytes = 128 bits
        private const int HashSize = 32;      // 32 bytes = 256 bits
        private const int Iterations = 100_000; // عدّل لو تحب (المزيد = أبطأ لكن أكثر أماناً)

        // هنا نخزن النتيجة بالشكل: {iterations}.{base64Salt}.{base64Hash}
        public static string HashPassword(string password)
        {
            if (password == null) throw new ArgumentNullException(nameof(password));

            // 1) جنّر salt عشوائي
            byte[] salt = new byte[SaltSize];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(salt);
            }

            // 2) اشتق الـ hash باستخدام PBKDF2
            byte[] hash;
            using (var pbkdf2 = new Rfc2898DeriveBytes(password, salt, Iterations, HashAlgorithmName.SHA256))
            {
                hash = pbkdf2.GetBytes(HashSize);
            }

            // 3) رجّع النص مع معلومات التهيئة
            string result = $"{Iterations}.{Convert.ToBase64String(salt)}.{Convert.ToBase64String(hash)}";
            return result;
        }

        // تحقق من الباسوورد مقارنة بالسلسلة المخزنة
        public static bool VerifyPassword(string password, string storedHash)
        {
            if (password == null) throw new ArgumentNullException(nameof(password));
            if (string.IsNullOrWhiteSpace(storedHash)) return false;

            // صيغة متوقعة: iterations.salt.hash
            var parts = storedHash.Split('.');
            if (parts.Length != 3) return false;

            if (!int.TryParse(parts[0], out int iterations)) return false;
            byte[] salt = Convert.FromBase64String(parts[1]);
            byte[] hash = Convert.FromBase64String(parts[2]);

            // اشتق hash جديد من كلمة المرور المدخلة بنفس الإعدادات
            byte[] computedHash;
            using (var pbkdf2 = new Rfc2898DeriveBytes(password, salt, iterations, HashAlgorithmName.SHA256))
            {
                computedHash = pbkdf2.GetBytes(hash.Length);
            }

            // مقارنه ثابتة الوقت (resists timing attacks)
            return FixedTimeEquals(hash, computedHash);
        }

        // مقارنة ثابتة الوقت للبايت أررايز
        private static bool FixedTimeEquals(byte[] a, byte[] b)
        {
            if (a == null || b == null) return false;
            if (a.Length != b.Length) return false;

            int diff = 0;
            for (int i = 0; i < a.Length; i++)
                diff |= a[i] ^ b[i];

            return diff == 0;
        }
    }

    public class UserBLL
    {
        private enum enMode { AddMode = 1, UpdateMode = 2 };
        private enMode _mode = enMode.AddMode;

        private User _user;

        public UserBLL()
        {
            _user = new User();
            _mode = enMode.AddMode;
        }

        public UserBLL(User user)
        {
            _user = user;
            _mode = enMode.UpdateMode;
        }

        public User Users
        {
            get { return _user; }
            set { _user = value; }
        }

        // جلب كل المستخدمين
        public static DataTable GetAllUsers()
        {
            return UserDLL.GetAllUsers();
        }

        public static DataTable GetAllUsersView()
        {
            return UserDLL.GetAllUsersView();
        }

        // إضافة مستخدم جديد
        private bool _Add()
        {
            _user.UserID = UserDLL.AddNewUser(_user);
            return _user.UserID != -1;
        }

        // تحديث مستخدم
        private bool _Update()
        {
            return UserDLL.UpdateUser(_user);
        }

        // حذف مستخدم
        public static bool Delete(short userID)
        {
            return UserDLL.DeleteUser(userID);
        }

        // البحث عن مستخدم بالـ ID
        public static User Find(short userID)
        {
            return UserDLL.GetUserByID(userID);
        }

        public static User FindUserForLogin(string username, string password)
        {
            User user = UserDLL.GetUserByUsername(username); // جلب اليوزر من قاعدة البيانات
            if (user == null) return null;

            // تحقق من كلمة المرور باستخدام Hash
            if (!PasswordHasher.VerifyPassword(password, user.PasswordHash))
                return null;

            return user;
        }

        public static bool FindUserByEmployeeID(int EmployeeID)
        {
            return UserDLL.FindUserByEmployeeID(EmployeeID);
        }

        public bool VerifyOldPassword(int userId, string enteredPassword)
        {
            string storedHash = UserDLL.GetPasswordHashByUserID(userId);

            if (string.IsNullOrEmpty(storedHash))
                return false;

            return PasswordHasher.VerifyPassword(enteredPassword, storedHash);
        }

        // الحفظ (إضافة أو تحديث)
        public bool Save()
        {
            switch (_mode)
            {
                case enMode.AddMode:
                    if (_Add())
                    {
                        _mode = enMode.UpdateMode;
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                case enMode.UpdateMode:
                    return _Update();
            }
            return false;
        }
    }
}
