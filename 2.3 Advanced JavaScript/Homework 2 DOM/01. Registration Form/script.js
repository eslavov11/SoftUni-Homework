function editDom() {
    if (document.getElementById('check').checked) {
        document.getElementById('factureSection').style.display = "block";
    } else {
        document.getElementById('factureSection').style.display = "none";
        document.body.innerHTL = "55";
    }
}
