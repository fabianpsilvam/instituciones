function validate(evt) {
    var theEvent = evt || window.event;
    var key = theEvent.keyCode || theEvent.which;
    key = String.fromCharCode(key);
    var regex = /[0-9]|\./;
    if (!regex.test(key)) {
        theEvent.returnValue = false;
        if (theEvent.preventDefault) theEvent.preventDefault();
    }
}


function selectRadioButton(radio) {
    var rdBtn = document.getElementById(radio.id);
    var rbList = document.getElementsByTagName("input");
    for (i = 0; i < rbList.length; i++) {
        if (rbList[i].type == "radio" && rbList[i].id != rdBtn.id) {
            rbList[i].checked = false;
        }
    }
}