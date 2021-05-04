function solve(inputArr) {
    const arr = [];

    const cmds = [];
    for (const line of inputArr) {
        const lines = line.split(' ');
        const cmd = lines[0];
        const parameter = lines[1];
        cmds.push({ cmd, parameter });
    }

    doOperation = {
        add: (str) => { arr.push(str) },
        remove: (str) => {
           let index = arr.indexOf(str);
           arr.splice(index, 1);
        },
        print: () => {
            console.log(arr.join(','));
        }

    }

    for (const command of cmds) {
        const commandToDo = command.cmd;
        doOperation[commandToDo](command.parameter);
        // if (commandToDo === 'print'){
        //     doOperation[commandToDo]();
        // }else{
        //     doOperation[commandToDo](command.parameter);
        // }
    }


}

solve(['add hello', 'add again', 'remove hello', 'add again', 'print']);