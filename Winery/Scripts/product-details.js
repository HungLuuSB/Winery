function increaseQuantity() {
    var input = document.getElementById("quantity");
    var quantity = parseInt(input.value) + 1;
    input.value = quantity;
}
function decreaseQuantity() {
    var input = document.getElementById("quantity");
    var quantity = parseInt(input.value) - 1;
    if (quantity > 0) {
        input.value = quantity;
    }
}
