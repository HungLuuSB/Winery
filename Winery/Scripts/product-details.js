function increaseQuantity() {
    var input = document.getElementById("quantity").value;
    input += 1;
}
function deccreaseQuantity() {
    var input = document.getElementById("quantity").value;
    if (input > 1) {
        input -= 1;
    }
}