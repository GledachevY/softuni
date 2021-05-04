
function createCard(face, suit) {
    const validFaces = ['2', '3', '3', '4', '5', '6', '7', '8', '9', '10', 'J', 'Q', 'K', 'A'];


    const suitToUtf = {
        S: '\u2660',
        H: '\u2665',
        D: '\u2666',
        C: '\u2663'
    }

    if (!validFaces.includes(face)) {
        return `Invalid card: ${face}${suitToUtf[suit]}`;
    }

    if (!Object.keys(suitToUtf).includes(suit)) {
        return `Invalid card: ${face}${suitToUtf[suit]}`;
    }

    return `${face}${suitToUtf[suit]}`;
}




function printDeckOfCards(cards) {

    const resultArr = [];

    for (const card of cards) {
        let inputFace;
        let inputSuit;

        if (card.length === 3) {
            inputFace = `${card[0]}${card[1]}`;
            inputSuit = card[2];
        } else if (card.length === 2) {
            inputFace = card[0];
            inputSuit = card[1];
        } else {
            throw new Error('Input length error');
        }

        resultArr.push(createCard(inputFace, inputSuit));
    }


    const str = resultArr.join(' ');
    return str;
}
