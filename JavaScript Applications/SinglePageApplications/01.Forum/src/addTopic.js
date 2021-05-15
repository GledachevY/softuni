import {showTopics} from './showPost.js'

function cleatInputFIelds() {
    document.getElementById('topicName').value = '';
        document.getElementById('username').value = '';
        document.getElementById('postText').value = '';
}
function cancelBtn() {
    document.getElementById('cancelBtn').addEventListener('click', (e)=>{
        e.preventDefault();
        cleatInputFIelds();
    })
}

async function addTopic() {


    document.getElementById('postBtn').addEventListener('click', (e) => {
        e.preventDefault();

        const form = new FormData(document.querySelector('form'));

        const title = form.get('topicName');
        const user = form.get('username');
        const text = form.get('postText');
        let date = Date.now();
        date = new Date(date);
        date = date.toDateString();

        cleatInputFIelds();

        const url = 'http://localhost:3030/jsonstore/collections/myboard/posts';
        const response = fetch(url, {
            method: 'post',
            headers: { 'Content-Type': 'application/json' },
            body: JSON.stringify({ title, user, text, date })

        })

         showTopics();

    })



}

export { addTopic,cancelBtn};