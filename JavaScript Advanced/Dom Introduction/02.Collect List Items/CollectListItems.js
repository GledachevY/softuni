function extractText() {
    const rows = document.querySelectorAll('ul#items li');

    let rowsArr = Array.from(rows);

    let result = '';
    for(let item of rowsArr){
        result += item.textContent + '\n';
    }
    const show = document.querySelector('#result');
    show.textContent = result;
}