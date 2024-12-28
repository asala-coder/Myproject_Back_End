// التحقق من صحة النموذج قبل الإرسال
document.getElementById('LoginForm').addEventListener('submit', function (event) {
    var email = document.getElementById('Email').value.trim();
    var password = document.getElementById('Password').value.trim();
    var emailPattern = /^[^\s@]+@[^\s@]+\.[^\s@]+$/; // التحقق من صيغة البريد الإلكتروني
    var passwordPattern = /^(?=.*[a-zA-Z])(?=.*\d)(?=.*[!@#$%^&*()_+\-=\[\]{};':"\\|,.<>\/?]).{6,}$/; // التحقق من كلمة المرور

    // ✅ التحقق من الحقول الفارغة
    if (!email) {
        alert('Please enter your email.');
        event.preventDefault();
        return;
    }

    if (!password) {
        alert('Please enter your password.');
        event.preventDefault();
        return;
    }

    // ✅ التحقق من صحة البريد الإلكتروني
    if (!emailPattern.test(email)) {
        alert('Please enter a valid email address.');
        event.preventDefault();
        return;
    }

    // ✅ التحقق من كلمة المرور
    if (!passwordPattern.test(password)) {
        alert('Password must be at least 6 characters long and include letters, numbers, and special characters.');
        event.preventDefault();
        return;
    }
});
