function solve() {
    const nameInput = document.querySelector('[name="lecture-name"]');
    const dateInput = document.querySelector('[name="lecture-date"]');
    const moduleInput = document.querySelector('[name="lecture-module"]');
    //console.log(nameInput, dateInput,moduleInput);
    const addButton = document.querySelector('button').addEventListener('click', (event) => {
        event.preventDefault();
        const nameValue = nameInput.value;
        const dateValue = dateInput.value;
        const moduleValue = moduleInput.value;
        if (nameValue !== '' && dateValue !== '' && moduleValue !== 'Select module') {
            const modulesDivElement = document.querySelector('.modules');
            let h3Elements = document.querySelectorAll('body h3');
            if (h3Elements.length === 1) {

                const moduleElement = document.createElement('div');
                moduleElement.classList.add('module');
                h3ElementsInside = document.createElement('h3');
                h3ElementsInside.textContent = `${moduleValue.toUpperCase()}-MODULE`;
                moduleElement.appendChild(h3ElementsInside);

                const ulELement = document.createElement('ul');

                const liElement = document.createElement('li');
                liElement.classList.add("flex");

                const h4Element = document.createElement('h4');
                h4Element.textContent = `${nameValue} - ${taskDate(dateValue)} `;
                liElement.appendChild(h4Element);

                const btnDelete = document.createElement('button');
                btnDelete.classList.add('red');
                btnDelete.textContent = 'Del';
                liElement.appendChild(btnDelete);

                ulELement.appendChild(liElement);

                moduleElement.appendChild(ulELement);

                modulesDivElement.appendChild(moduleElement);

                const sorted = Array.from(ulELement.children
                    ).sort(sortingFunc);
                    console.log(sorted);

                sorted.forEach((el)=>ulELement.appendChild(el));


            } else if (Array.from(h3Elements).some((el) => el.textContent.includes(moduleValue.toUpperCase()))) {

                const duplicateh3Element = Array.from(h3Elements).find((el) => el.textContent.includes(moduleValue.toUpperCase()));

                const moduleElement = duplicateh3Element.parentElement;
                //console.log(moduleElement);
                const ulELement = moduleElement.children[1];

                const liElement = document.createElement('li');
                liElement.classList.add("flex");

                const h4Element = document.createElement('h4');
                h4Element.textContent = `${nameValue} - ${taskDate(dateValue)} `;
                liElement.appendChild(h4Element);

                const btnDelete = document.createElement('button');
                btnDelete.classList.add('red');
                btnDelete.textContent = 'Del';
                liElement.appendChild(btnDelete);

                ulELement.appendChild(liElement);

                moduleElement.appendChild(ulELement);
               
                const sorted = Array.from(ulELement.children
                    ).sort(sortingFunc);
                    console.log(sorted);

                sorted.forEach((el)=>ulELement.appendChild(el));


            } else {
                const moduleElement = document.createElement('div');
                moduleElement.classList.add('module');
                h3ElementsInside = document.createElement('h3');
                h3ElementsInside.textContent = `${moduleValue.toUpperCase()}-MODULE`;
                moduleElement.appendChild(h3ElementsInside);

                const ulELement = document.createElement('ul');

                const liElement = document.createElement('li');
                liElement.classList.add("flex");

                const h4Element = document.createElement('h4');
                h4Element.textContent = `${nameValue} - ${taskDate(dateValue)} `;
                liElement.appendChild(h4Element);

                const btnDelete = document.createElement('button');
                btnDelete.classList.add('red');
                btnDelete.textContent = 'Del';
                liElement.appendChild(btnDelete);

                ulELement.appendChild(liElement);

                moduleElement.appendChild(ulELement);

                modulesDivElement.appendChild(moduleElement);

                const sorted = Array.from(ulELement.children
                    ).sort(sortingFunc);
                    console.log(sorted);

                sorted.forEach((el)=>ulELement.appendChild(el));
            }
        }
    });

    document.querySelector('body').addEventListener('click', (event)=>{
        const btn = event.target;
        if(btn.textContent == 'Del'){
            //console.log(true);
            const currentLiElement = btn.parentElement;
            const currentUlElement = currentLiElement.parentElement;
            currentLiElement.remove();
            console.log(currentUlElement);
            if(currentUlElement.children.length ==0){
                const divTORemove = currentUlElement.parentElement;
                divTORemove.remove();
            }
        }
    })
    function taskDate(dateMilli) {
        var m = new Date(dateMilli);
        var dateString =
            m.getUTCFullYear() + "/" +
            ("0" + (m.getUTCMonth() + 1)).slice(-2) + "/" +
            ("0" + m.getUTCDate()).slice(-2) + " - " +
            ("0" + m.getHours()).slice(-2) + ":" +
            ("0" + m.getMinutes()).slice(-2)
    
        return dateString;
    }
    
    function sortingFunc(a,b){
        
            if(a.children[0].textContent>b.children[0].textContent){
                return 1
            }
            if(a.children[0].textContent<b.children[0].textContent){
                return -1
            } 
            return 0;
        
    }

}
