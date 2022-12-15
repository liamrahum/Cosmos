function UserValid() {
    var x = document.getElementById("username").value;
    var Utext = document.getElementById("uText");
    if (x == "") {
        Utext.innerHTML = "<p> please enter a valid username </p>";
        return false;
    }
    else if (!isLetter(x[0])) {
        Utext.innerHTML = "<p> Username must start with a letter </p>";
        return false;
    }
    Utext.innerHTML = "";
    return true;
}

function isLetter(str) {
    return str.length === 1 && str.match(/[a-z]/i);
}

function passValid() {
    var y = document.getElementById("pwd").value;
    var Ptext = document.getElementById("pText");
    if (y == '') {
        Ptext.innerHTML = "<p> please enter a valid password </p>";
        return false;
    }
    else if (y.length < 2) {
        Ptext.innerHTML = "<p> Password must contain at least 7 characters </p>";
        return false;
    }
    else if (!containsSpecialChars(y)) {
        Ptext.innerHTML = "<p> Password must contain at least one spcial character </p>";
        return false;
    }
    else if (y.length < 7) {
        Ptext.innerHTML = "<p> Password must contain 7 chars or more</p>";
        return false;
    }
    Ptext.innerHTML = "";
    return true;
}

function resetPassValid() {
    var y = document.getElementById("newPass").value;
    var Ptext = document.getElementById("pText");
    if (y == '') {
        Ptext.innerHTML = "<p> please enter a valid password </p>";
        return false;
    }
    else if (y.length < 2) {
        Ptext.innerHTML = "<p> Password must contain at least 7 characters </p>";
        return false;
    }
    else if (!containsSpecialChars(y)) {
        Ptext.innerHTML = "<p> Password must contain at least one spcial character </p>";
        return false;
    }
    else if (y.length < 7) {
        Ptext.innerHTML = "<p> Password must contain 7 chars or more</p>";
        return false;
    }
    Ptext.innerHTML = "";
    return true;
}

function containsSpecialChars(str) {
    const specialChars = /[`!@#$%^&*()_+\-=\[\]{};':"\\|,.<>\/?~]/;
    return specialChars.test(str);
}


function isLoginValid() {
    return PassValid() && UserValid();
}

function check_name() {
    var y = document.getElementById("firstname").value;
    var Ptext = document.getElementById("fText");
    if (y == '') {
        Ptext.innerHTML = "<p> please enter your name </p>";
        return false;
    }
    Ptext.innerHTML = "";   
    return true;
}

function check_Lastname() {
    var y = document.getElementById("lastname").value;
    var Ptext = document.getElementById("lText");
    if (y == '') {
        Ptext.innerHTML = "<p> please enter your last name </p>";
        return false;
    }
    Ptext.innerHTML = "";
    return true;
}

function check_city() {
    var y = document.getElementById("city").value;
    var Ptext = document.getElementById("cText");
    if (y == '') {
        Ptext.innerHTML = "<p> please enter your city </p>";
        return false;
    }
    Ptext.innerHTML = "";
    return true;
}

function check_phone() {
    var y = document.getElementById("phone").value;
    var Ptext = document.getElementById("phoneText");
    var i = 0;
    if (y == '') {
        Ptext.innerHTML = "<p> please enter your phone </p>";
        return false;
    }
    if (y[0] != '0') {
        Ptext.innerHTML = "<p>Must start with 0</p>";
        return false;
    }
    if (y.match(/^[0-9]+$/) == null) {
        Ptext.innerHTML = "<p> Numbers only. </p>";
        return false;
    }
    if (y.match(/^[--]+$/) == null) {
        Ptext.innerHTML = "<p>Must contain - </p>";
        return false;
    }
    Ptext.innerHTML = "";
    return true;
}

function check_email() {
    var y = document.getElementById("email").value;
    var Ptext = document.getElementById("eText");
    if (y == '') {
        Ptext.innerHTML = "<p> please enter your email </p>";
        return false;
    }
    if (!y.test(/[@]/)) {
        Ptext.innerHTML = "<p> invalid email </p>";
        return false;
    }
    Ptext.innerHTML = "";
    return true;
}

function validForm() {
    var isValid = passValid() && UserValid() && check_name() && check_Lastname() && check_city() && check_phone() && check_email();
    return isValid;
}