document.addEventListener('scroll', () => {
    const header = document.getElementById('navbar-content-main');
    if (window.scrollY > 0) {
        header.classList.add('scrolled');
    } else {
        header.classList.remove('scrolled');
    }
})