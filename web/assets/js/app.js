(function initPage() {

    const btnViewAll = document.querySelector('.btn__viewall')
    const btnPrevious = document.querySelector('#btn-previous')
    const btnClose = document.querySelector('#btn-close')
    const btnNext = document.querySelector('#btn-next')
    let manufacturers = []
    let cardIndex = 0

    const cardTitle = document.querySelector('#card-title')
    const cardSubtitle = document.querySelector('#card-subtitle')
    const cardPhone = document.querySelector('#card-phone')

    const coffeeshopFullpage = new fullpage("#coffeeshop__fullpage", {
        navigation: true,
        anchors: ['welcome', 'whoarewe', 'manufacturers'],
        scrollingSpeed: 750,
        autoScrolling: true,
        licenseKey: "590BFCB8-B12540DA-9B69994D-BB706C1B",
        navigationTooltips: ['Welcome', 'Who are we?', 'Top brands'],
        scrollBar: false,
        easing: 'easeInOutCubic',
        easingcss3: 'ease',
        dragAndMove: 'mouseonly',
        sectionSelector: '.coffeeshop__section',
        menu: '#coffeeshop__menu',
        parallax: true,
        parallaxOptions: {
            type: 'reveal',
            percentage: 62,
            property: 'translate'
        }
    })

    const createCard = cardDetails => {

        const mainDiv = document.createElement("div")
        mainDiv.classList.add("manufacturer__card")

        const divVisuals = document.createElement("div")
        const divTexts = document.createElement("div")

        divVisuals.classList.add("card__visual")
        divTexts.classList.add("card__texts")

        const textTitle = document.createElement("h2")
        textTitle.classList.add("title")
        textTitle.innerHTML = cardDetails.name

        pSubtitle = document.createElement("p")
        pSubtitle.classList.add("subtitle")
        pSubtitle.innerHTML = cardDetails.country + ", " + cardDetails.address

        const divLine = document.createElement("div")
        divLine.classList.add("line")

        const pDesc = document.createElement("p")
        pDesc.classList.add("desc")
        pDesc.innerHTML = "Lorem ipsum dolor sit amet, consectetur adipisicing elit. Veritatis rerum laudantium soluta ipsam voluptatum."



        // Reade more button

        const divButton = document.createElement("div")
        divButton.classList.add("card__btn")
        const btnReadMore = document.createElement("button")
        btnReadMore.innerHTML = "Read more"
        divButton.appendChild(btnReadMore)

        // Contact div

        const divContact = document.createElement("div")
        divContact.classList.add("card__contact")

        const contactTitle = document.createElement("h2")
        contactTitle.classList.add("title")
        contactTitle.innerHTML = "Contact them"

        const contactPhone = document.createElement("i")
        contactPhone.classList.add("card__phone")
        contactPhone.innerHTML = cardDetails.phone

        divContact.appendChild(contactTitle)
        divContact.appendChild(contactPhone)


        divTexts.appendChild(textTitle)
        divTexts.appendChild(pSubtitle)
        divTexts.appendChild(divLine)
        divTexts.appendChild(pDesc)
        divTexts.appendChild(divButton)
        divTexts.appendChild(divContact)

        mainDiv.appendChild(divVisuals)
        mainDiv.appendChild(divTexts)

        return mainDiv;

    }

    const createTopManufacturers = async function () {

        const response = await fetch('https://heroku-patrik.herokuapp.com/api/manufacturer');
        manufacturers = await response.json();
        const numberOfCardsToShow = manufacturers.length < 3 ? manufacturers.length : 3;

        document.querySelector('.dots__loader').style.display = "none"
        btnViewAll.style.display = "block"
        if (numberOfCardsToShow > 3) {

        }

        const cardContainer = document.querySelector('.manufacturers__container')


        for (let i = 0; i < numberOfCardsToShow; i++) {
            const newCard = createCard(manufacturers[i])
            cardContainer.appendChild(newCard)
        }

    }

    const updateCard = () => {
        cardTitle.innerHTML = manufacturers[cardIndex].name
        cardSubtitle.innerHTML = manufacturers[cardIndex].country + ', ' + manufacturers[cardIndex].address
        cardPhone.innerHTML = manufacturers[cardIndex].phone
    }

    btnViewAll.addEventListener('click', function () {
        cardIndex = 0;
        updateCard()
        document.querySelector('.viewall__container').style.display = 'flex'
    })


    btnPrevious.addEventListener('click', function () {
        cardIndex--
        if (cardIndex == -1) {
            cardIndex = manufacturers.length - 1
        }
        updateCard()
    })

    btnClose.addEventListener('click', function () {
        document.querySelector('.viewall__container').style.display = 'none'
    })

    btnNext.addEventListener('click', function () {
        cardIndex++
        if (cardIndex == manufacturers.length) {
            cardIndex = 0
        }
        updateCard()
    })


    // Create the cards
    createTopManufacturers()

})()

// API urls
// https://heroku-patrik.herokuapp.com/api/manufacturer
// https://heroku-patrik.herokuapp.com/api/manufacturer/@id