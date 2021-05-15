function addComment() {
    const allCommentsElements = document.querySelectorAll('.topic-container');
    const result = allCommentsElements.forEach(el => el.addEventListener('click', commentClick));

}


function commentClick(e) {
    e.preventDefault();

    let idToExport;
    let element = e.target;

    while (element.className != 'topic-container') {
        element = element.parentNode;
    }

    idToExport = element.id;

    window.location = "theme-content.html?commentId=" + idToExport;
}

export { addComment };
