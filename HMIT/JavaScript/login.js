function validate() {
    var email = document.getElementById("email").value;
    var password = document.getElementById("password").value;
    var error = document.getElementById("error");
    error.innerHTML = "";

    if (email == "") {
        error.innerHTML = "Please enter an email.";
        return false;
    }

    if (password == "") {
        error.innerHTML = "Please enter a password.";
        return false;
    }

    if (email != "myemail" || password != "mypassword") {
        error.innerHTML = "Incorrect email or password.";
        return false;
    }

    alert("Login successful!");
    return true;
}