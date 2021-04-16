function sumTable() {
    const toModify = [...document.querySelectorAll('table tr')].slice(1, -1);
    const result = toModify.reduce((sum,cur) => sum+=Number(cur.children[cur.children.length - 1].textContent), 0);
    let placeToShow = document.getElementById('sum');
    placeToShow.textContent = result;
}