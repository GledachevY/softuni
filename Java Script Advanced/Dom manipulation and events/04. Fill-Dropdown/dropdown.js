function addItem() {
    const text = document.getElementById('newItemText');
    const itemValue = document.getElementById('newItemValue');
    const menu = document.getElementById('menu');

    const optionElement = document.createElement('option')
    optionElement.textContent = text.value;
    optionElement.value = itemValue.value;


    menu.appendChild(optionElement);

    text.value = '';
    itemValue.value = '';

}