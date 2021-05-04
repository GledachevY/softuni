async function loadCommits() {
    const usernameInput = document.getElementById('username').value;
    const repoInput = document.getElementById('repo').value;

    const url = `https://api.github.com/repos/${usernameInput}/${repoInput}/commits`;

    const commitsElement = document.querySelector('#commits');
    console.log(commitsElement);

    try {
        const response = await fetch(url);
        console.log(response);

        const data = await response.json();
        console.log(data);
        if(response.status === 404){
            throw new Error('Not found');
        }
        commitsElement.innerHTML='';

        
        data.forEach(info => {
           const liElement =  e('li', {}, info.commit.author.name, info.commit.message);
            commitsElement.appendChild(liElement);
        });



    } catch (err) {
        const errorLiElement = e('li',{},err.message);
       
         commitsElement.innerHTML='';
         commitsElement.appendChild(errorLiElement);

    }
    function e(type, attributes, ...content) {
        const result = document.createElement(type);

        for (let [attr, value] of Object.entries(attributes || {})) {
            if (attr.substring(0, 2) == 'on') {
                result.addEventListener(attr.substring(2).toLocaleLowerCase(), value);
            } else {
                result[attr] = value;
            }
        }

        content = content.reduce((a, c) => a.concat(Array.isArray(c) ? c : [c]), []);

        content.forEach(e => {
            if (typeof e == 'string' || typeof e == 'number') {
                const node = document.createTextNode(e);
                result.appendChild(node);
            } else {
                result.appendChild(e);
            }
        });

        return result;
    }
}
