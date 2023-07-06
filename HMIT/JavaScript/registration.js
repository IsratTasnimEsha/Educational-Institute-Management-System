function totalCredit() {
    var checkboxes = document.querySelectorAll('.checkbox');

    var sum=0.0;

    for (var i = 0; i < checkboxes.length; i++) {
        if (checkboxes[i].checked) {
            var row = checkboxes[i].parentNode.parentNode;

            var statusElements = row.querySelectorAll('.status');

            sum+= parseFloat(statusElements[2].textContent);

            //for (var j = 0; j < statusElements.length; j++) {
            //    alert(statusElements[j].textContent);
            //}
        }
    }
    
    var credit = document.getElementById("credit");
    credit.innerHTML = sum;   
}