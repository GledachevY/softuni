function validate() {
    
    document.getElementById('email').addEventListener('change', onChange);
    
    function onChange(event){
        const divToEdit = document.getElementById('email');
        const email = document.getElementById('email').value;
        if(/^[a-z]+@[a-z]+\.[a-z]+$/.test(email)){
            divToEdit.className = '';
        }else{
            divToEdit.className = 'error';
        }
    }
}