function lockedProfile() {

    document.getElementById('main').addEventListener('click', onClick);

    function onClick(event) {
        if (event.target.tagName == 'BUTTON') {

            const btnn = event.target;

            let isLocked = btnn.parentNode.querySelector('input[type=radio]:checked').value === 'lock';
            const div = btnn.parentNode.querySelector('div');

            if (!isLocked && btnn.textContent === 'Show more') {
                div.style.display = 'block';

                btnn.textContent = 'Hide it';

            } else if (!isLocked && btnn.textContent === 'Hide it') {
                div.style.display = 'none';
                btnn.textContent = 'Show more';
            }

        }

    }

}