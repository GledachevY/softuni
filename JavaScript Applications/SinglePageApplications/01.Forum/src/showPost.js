async function showTopics() {
    const url = 'http://localhost:3030/jsonstore/collections/myboard/posts'
    const response = await fetch(url);
    const data = await response.json();

    console.log( Object.values(data));

    const postConatiner = document.querySelectorAll('main>div')[1];

    Object.values(data).map((d) => postConatiner.innerHTML += `<div class="topic-container">
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

    )

}

export { showTopics };