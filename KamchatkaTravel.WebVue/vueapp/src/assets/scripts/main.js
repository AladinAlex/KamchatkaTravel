import '@/assets/scripts/libs/bigger-picture.min.js'
import '@/assets/scripts/libs/hystmodal.min.js'
import '@/assets/scripts/libs/imask.min.js'
import '@/assets/scripts/libs/parallax.min.js'
import '@/assets/scripts/libs/simpleParallax.min.js'
import '@/assets/scripts/libs/swiper-bundle.min.js'

function smoothView(btn, el, startHeight = 0) {

    if (!btn && !el) return

    const add = () => {
        btn.classList.add('not-active')
        el.classList.add('not-active')
    }

    const remove = () => {
        btn.classList.remove('not-active')
        el.classList.remove('not-active')
    }

    let heightEl = el.offsetHeight
    add()
    el.style.height = `${startHeight}px`

    if (startHeight > 0) {
        if (heightEl < startHeight) {
            remove()
            el.style.height = `${heightEl}px`
        }
    }

    const update = () => {
        el.style.height = 'auto'
        setTimeout(() => {
            heightEl = el.offsetHeight
            el.style.height = `${heightEl}px`
        }, 100)
    }

    btn.addEventListener('click', () => {
        if (el.classList.contains('not-active')) {
            remove()
            el.style.height = `${heightEl}px`
        } else {
            add()
            el.style.height = `${startHeight}px`
        }
    })

    let observer = new MutationObserver(mutationRecords => {
        update()
    })

    observer.observe(el, {
        childList: true,
        subtree: true,
        characterDataOldValue: true
    })
}

function page() {
    const main = document.querySelector('[data-page="main"]')
    const header = document.querySelector('[data-header="main"]')

    if (!main) return
    if (!header) return
    
    const wrapperContent = main.querySelector('[data-page="wrapper-content"]')

    if (wrapperContent) {
        wrapperContent.style.paddingTop = `${header.offsetHeight}px`
    } else {
        main.style.paddingTop = `${header.offsetHeight}px`
    }
}

function header() {
    const header = document.querySelector('[data-header="main"]')

    if (!header) return

    const menu = header.querySelector('[data-header="menu"]')
    const btnMenu = header.querySelector('[data-header="btn-menu"]')
    const navUl = header.querySelector('[data-header="nav-ul"]')

    window.addEventListener('scroll', (event) => {
        const scrolled = window.pageYOffset ? window.pageYOffset : document.body.scrollTop;

        if (scrolled >= 100) {
            header.classList.add('header--fixed')
        } else {
            header.classList.remove('header--fixed')
        }
    })

    if (window.matchMedia("(max-width: 992px)").matches) {
        btnMenu.addEventListener('click', () => {
            btnMenu.classList.toggle('active')
            menu.classList.toggle('active')
        })

        navUl.addEventListener('click', (event) => {
            if (event.target.closest('a')) {
                btnMenu.classList.remove('active')
                menu.classList.remove('active')
            }
        })
    }
}

function presentation() {
    const main = document.querySelector('[data-presentation="main"]')

    if (!main) return

    const blockParallax = main.querySelector('[data-presentation="block-parallax"]')

    const parallaxInstance = new Parallax(blockParallax, {
        hoverOnly: true
    })
}

function modalPicture() {

    const blockPictures = document.querySelectorAll('[data-modal-picture="main"]')

    if (!blockPictures.length) return

    let bp = BiggerPicture({
        target: document.body,
    })

    const openGallery = (event, pictures) => {
        event.preventDefault()
        bp.open({
            items: pictures,
            el: event.currentTarget,
        })
    }

    blockPictures.forEach(blockPicture => {
        const pictures = blockPicture.querySelectorAll('a[data-modal-picture="link"]')

        if (pictures.length) {

            pictures.forEach(picture => {
                const image = picture.querySelector('img')
                const imageSource = image.getAttribute('src')
                const img = new Image()

                img.onload = function () {
                    const width = this.width
                    const hight = this.height

                    picture.setAttribute('data-height', hight * 4)
                    picture.setAttribute('data-width', width * 4)
                }

                img.src = imageSource;

                picture.addEventListener("click", (event) => {
                    openGallery(event, pictures)
                })
            })
        }
    })
}

function program() {
    const mains = document.querySelectorAll('[data-program="main"]')

    if (!mains.length) return

    mains.forEach(main => {
        const slider = main.querySelector('[data-program="slider"]')
        const btnPrev = main.querySelector('[data-program="btn-prev"]')
        const btnNext = main.querySelector('[data-program="btn-next"]')

        const swiper = new Swiper(slider, {
            spaceBetween: 20,
            autoHeight: true,
            navigation: {
              nextEl: btnNext,
              prevEl: btnPrev,
            },
        })
    })
}

function reviews() {
    const mains = document.querySelectorAll('[data-reviews="main"]')

    if (!mains.length) return

    mains.forEach(main => {
        const slider = main.querySelector('[data-reviews="slider"]')
        const btnPrev = main.querySelector('[data-reviews="btn-prev"]')
        const btnNext = main.querySelector('[data-reviews="btn-next"]')

        const swiper = new Swiper(slider, {
            slidesPerView: 1,
            spaceBetween: 20,
            autoHeight: true,
            navigation: {
              nextEl: btnNext,
              prevEl: btnPrev,
            },
            breakpoints: {
                992: {
                  slidesPerView: 2,
                },
            }
        })
    })
}

function scrollParallax() {
    const items = document.querySelectorAll('[data-scroll-parallax]')

    if (!items.length) return

    new simpleParallax(items, {
        delay: .3,
        scale: 1.2,
        transition: 'cubic-bezier(0,0,0,1)'
    })
}

function faq() {
    const mains = document.querySelectorAll('[data-faq="main"]')

    if (!mains.length) return

    mains.forEach(main => {
        const blocks = main.querySelectorAll('[data-faq="block"]')

        blocks.forEach(block => {
            const head = block.querySelector('[data-faq="head"]')
            const body = block.querySelector('[data-faq="body"]')

            smoothView(head, body)
        })
    })
}

function smoothScrolling() {
    const anchors = document.querySelectorAll('[data-smooth-scrolling*="#"]')

    if (!anchors.length) return

    document.addEventListener('click', (event) => {
        const el = event.target

        if (el.closest('[data-smooth-scrolling*="#"]')) {
            event.preventDefault()
            const anchor = el.closest('[data-smooth-scrolling*="#"]')
            
            const blockID = anchor.getAttribute('data-smooth-scrolling').substr(1)
            
            document.querySelector(`[data-smooth-scrolling="${blockID}"]`).scrollIntoView({
                behavior: 'smooth',
                block: 'start'
            })
        }
    })
}

function phoneMask() {
    const phoneMasks = document.querySelectorAll('[data-phone-mask]')

    if (!phoneMasks.length) return

    phoneMasks.forEach(phoneMask => {
        IMask(phoneMask, {
            mask: '+{7}(000)000-00-00'
        })
    })
}

function sorting() {
    const mains = document.querySelectorAll('[data-sorting="main"]')

    if (!mains.length) return

    document.addEventListener('click', (event) => {
        const el = event.target
        if (el.closest('[data-sorting="main"]')) {
            const sorting = el.closest('[data-sorting="main"]')

            mains.forEach(main => {
                if (main != sorting) {
                    main.classList.remove('active')
                }
            })

            if (el.closest('[data-sorting="block-head"]')) {
                sorting.classList.toggle('active')
            }

            if (el.closest('.radio')) {
                sorting.classList.remove('active')
            }

        } else {
            mains.forEach(main => main.classList.remove('active'))
        }
    })
}

function modal() {
    return new HystModal({
        linkAttributeName: "data-hystmodal",
        waitTransitions: true,
    })
}

page()
header()
presentation()
modalPicture()
program()
reviews()
scrollParallax()
faq()
phoneMask()
smoothScrolling()
sorting()
modal()