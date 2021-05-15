import { html, render } from '../../node_modules/lit-html/lit-html.js'

async function loadTopicHeader() {

    const idToSearch = getIdFromUrl();
    const response = await fetch(`http://localhost:3030/jsonstore/collections/myboard/posts/` + idToSearch);
    const data = await response.json();

    document.querySelector('.theme-name h2').textContent = data.title;

    const commentSection = document.querySelector('.comment');

    const commentsElement = await loadComments();

    const topicHeader = html`
    <div class="header">
        <img src="./static/profile.png" alt="avatar">
        <p><span>${data.user}</span> posted on <time>${data.date}</time></p>
        <p class="post-content">${data.text}</p>
        ${commentsElement.map(e => html`${e}`)}
    </div>
    `;

    render(topicHeader, commentSection);

}

async function addNewComment() {
    document.querySelector('form').addEventListener('submit', postComment);
    async function postComment(event) {
        event.preventDefault();
        const form = new FormData(event.target);
        const idOfTopic = getIdFromUrl();

        let date = Date.now();
        date = new Date(date);
        date = date.toDateString();

        const commentValue = form.get('postText')
        const usernameValue = form.get('username');
        event.target.reset();

        const response = await fetch(' http://localhost:3030/jsonstore/collections/myboard/comments', {
            method: 'post',
            headers: { 'Content-Type': 'application/json' },
            body: JSON.stringify({ commentValue, usernameValue, idOfTopic, date })
        });

        await loadTopicHeader();
    }


}

async function loadComments() {
    const idToSearch = getIdFromUrl();
    const response = await fetch(' http://localhost:3030/jsonstore/collections/myboard/comments');
    const data = await response.json();

    const dataAsArr = Object.values(data).filter(c => c.idOfTopic == idToSearch);

    console.log(dataAsArr);
    if (dataAsArr.length == 0) {
        return
    }

    const commentSection = document.querySelector('.comment');

    const commentElement = (c) => html`
    <div id="${c._id}">
        <div class="topic-name-wrapper">
            <div class="topic-name">
                <p><strong>${c.usernameValue}</strong> commented on <time>${c.date}</time></p>
                <div class="post-content">
                    <p>${c.commentValue}</p>
                </div>
            </div>
        </div>
    </div>
    `;
    const commentElementToAppend = dataAsArr.map(commentElement);

    return commentElementToAppend;

}

function getIdFromUrl() {
    const urlParams = new URLSearchParams(window.location.search);
    const idToSearch = urlParams.get('commentId');
    return idToSearch;
}

function home(){
    
    document.querySelector('body a').addEventListener('click', (e)=>{
        window.location = 'index.html';
    })
}

loadTopicHeader();

addNewComment();

home();