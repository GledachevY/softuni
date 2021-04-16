function editElement(ref, match,replacer) {

    let text = ref.textContent;

    let regex = new RegExp(match, 'g');

   const result = text.replace(regex, replacer);

    ref.textContent = result;
    
}