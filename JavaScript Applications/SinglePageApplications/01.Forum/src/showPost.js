import { html, render } from '../../node_modules/lit-html/lit-html.js'

async function showTopics() {
    const url = 'http://localhost:3030/jsonstore/collections/myboard/posts'
    const response = await fetch(url);
    const data = await response.json();

    const postConatiner = document.querySelectorAll('main>div')[1];

    const shablon = (d) => html`
    <div id='${d._id}' class="topic-container">
        <div class="topic-name-wrapper">
            <div class="topic-name">
                <a href="#" class="normal">
                    <h2>${d.title}</h2>
                </a>
                <div class="columns">
                    <div>
                        <p>Date: <time>${d.date}</time></p>
                        <div class="nick-name">
                            <p>Username: <span>${d.user}</span></p>
                        </div>
                    </div>
    
    
                </div>
            </div>
        </div>
    </div>
    `

    const result = Object.values(data).map(shablon);

    render(result,postConatiner);

}

export { showTopics };