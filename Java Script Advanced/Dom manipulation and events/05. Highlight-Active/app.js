function focused() {
    Array.from(document.querySelectorAll('input')).forEach(field => {
        field.addEventListener('focus', onFocus);
        field.addEventListener('blur', onBlur);
    });

    function onFocus(ev){
        console.log( ev.target.parentNode);
        ev.target.parentNode.className = 'focus';

    }
    function onBlur(ev){
        ev.target.parentNode.className = '';

    }
}