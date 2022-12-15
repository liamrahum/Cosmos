function openTab(evt, tabName) {
    var i, x, tablinks;
    x = document.getElementsByClassName("course-tab");
    for (i = 0; i < x.length; i++) {
        x[i].style.display = "none";
    }
    tablinks = document.getElementsByClassName("cbutton");
    for (i = 0; i < x.length; i++) {
        tablinks[i].className = tablinks[i].className.replace(" active-cbutton", "");
    }
    document.getElementById(tabName).style.display = "block";
    evt.currentTarget.className += " active-cbutton";
}