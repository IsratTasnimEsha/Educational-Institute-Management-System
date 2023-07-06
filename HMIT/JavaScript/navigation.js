var navLinks = document.getElementById("navLinks");
var menu = document.getElementById("menu");

function showMenu() {
    navLinks.style.left="0";
    menu.style.display="none";
}

function hideMenu() {
    navLinks.style.left="-200px"
    menu.style.display="block";
}