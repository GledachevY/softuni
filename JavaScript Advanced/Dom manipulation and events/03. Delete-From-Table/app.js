function deleteByEmail() {
    
    const email = document.querySelector('input[name="email"]').value;
    const resiltDiv = document.getElementById('result');

    const emails = Array.from(document.querySelectorAll('tbody tr'));
    for(let row of emails){
        if(row.children[1].textContent === email){
            row.children[1].parentNode.remove();
            resiltDiv.textContent = 'Deleted';
        }else{
            resiltDiv.textContent = 'Not found.';
        }
    }

}