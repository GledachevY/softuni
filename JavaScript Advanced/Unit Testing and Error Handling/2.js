function createCard(face, suit) {
    const validFaces = ['2', '3', '3', '4', '5', '6', '7', '8', '9', '10', 'J', 'Q', 'K', 'A'];

    
    const suitToUtf = {
        S: '\u2660',
        H: '\u2665',
        D: '\u2666',
        C: '\u2663'
    }
    
    if (!validFaces.includes(face)) {
        throw new Error("asd");
    }

    if (!Object.keys(suitToUtf).includes(suit)) {
        throw new Error("asd");
    }

    return `${face}${suitToUtf[suit]}`;
}