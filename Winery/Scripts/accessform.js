function onShowPasswordChange(obj) {
    const passwordInput = document.getElementById('password');
    if (obj.checked) {
        passwordInput.type = 'text';
    } else {
        passwordInput.type = 'password';
    }
}