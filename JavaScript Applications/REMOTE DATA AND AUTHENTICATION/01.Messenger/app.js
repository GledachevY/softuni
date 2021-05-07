function attachEvents() {
    document.getElementById('refresh').addEventListener('click', getAllMEssages);
    document.getElementById('submit').addEventListener('click', sendAMessage);
    
}

attachEvents();

async function getAllMEssages(){
    const url = 'http://localhost:3030/jsonstore/messenger';
    const response = await fetch(url);
    const data = await response.json();

  
    document.getElementById('messages').value = Object.values(data).map(m => `${m.author}: ${m.content}`).join('\n');
}

async function sendAMessage(){
    const author = document.querySelector('#controls [name="author"]').value;
  
    const content = document.querySelector('#controls [name="content"]').value;
    console.log(content);
    const url = 'http://localhost:3030/jsonstore/messenger';
    const response = await fetch(url,{
        method: 'post',
        headers:{'Content-Type': 'application/json'},
        body: JSON.stringify( {author, content})
    });

    document.querySelector('#controls [name="author"]').value = '';
    document.querySelector('#controls [name="content"]').value ='';

    getAllMEssages();

}