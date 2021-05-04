function addItem() {
    const ulElement = document.getElementById('items');
    const text = document.getElementById('newItemText').value;

    const newLi = document.createElement('li');
    newLi.textContent = text;
    ulElement.appendChild(newLi);

}