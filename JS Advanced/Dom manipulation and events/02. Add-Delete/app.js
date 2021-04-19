function addItem() {
    const text = document.getElementById('newItemText').value;
    const ulElement = document.getElementById('items');

    const newLi = document.createElement('li');
    newLi.textContent = text;
    ulElement.appendChild(newLi);

    const delBtn = document.createElement('a');
    delBtn.textContent = 'Delete';
    delBtn.href = '#';
    newLi.appendChild(delBtn);

    delBtn.addEventListener('click', onDelete);

    function onDelete (event){
        event.target.parentNode.remove();
    }
}