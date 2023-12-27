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
//# sourceMappingURL=data:application/json;charset=utf-8;base64,eyJ2ZXJzaW9uIjozLCJuYW1lcyI6W10sIm1hcHBpbmdzIjoiIiwic291cmNlcyI6WyJtYWluLmpzIl0sInNvdXJjZXNDb250ZW50IjpbImZ1bmN0aW9uIHNtb290aFZpZXcoYnRuLCBlbCwgc3RhcnRIZWlnaHQgPSAwKSB7XHJcblxyXG4gICAgaWYgKCFidG4gJiYgIWVsKSByZXR1cm5cclxuXHJcbiAgICBjb25zdCBhZGQgPSAoKSA9PiB7XHJcbiAgICAgICAgYnRuLmNsYXNzTGlzdC5hZGQoJ25vdC1hY3RpdmUnKVxyXG4gICAgICAgIGVsLmNsYXNzTGlzdC5hZGQoJ25vdC1hY3RpdmUnKVxyXG4gICAgfVxyXG5cclxuICAgIGNvbnN0IHJlbW92ZSA9ICgpID0+IHtcclxuICAgICAgICBidG4uY2xhc3NMaXN0LnJlbW92ZSgnbm90LWFjdGl2ZScpXHJcbiAgICAgICAgZWwuY2xhc3NMaXN0LnJlbW92ZSgnbm90LWFjdGl2ZScpXHJcbiAgICB9XHJcblxyXG4gICAgbGV0IGhlaWdodEVsID0gZWwub2Zmc2V0SGVpZ2h0XHJcbiAgICBhZGQoKVxyXG4gICAgZWwuc3R5bGUuaGVpZ2h0ID0gYCR7c3RhcnRIZWlnaHR9cHhgXHJcblxyXG4gICAgaWYgKHN0YXJ0SGVpZ2h0ID4gMCkge1xyXG4gICAgICAgIGlmIChoZWlnaHRFbCA8IHN0YXJ0SGVpZ2h0KSB7XHJcbiAgICAgICAgICAgIHJlbW92ZSgpXHJcbiAgICAgICAgICAgIGVsLnN0eWxlLmhlaWdodCA9IGAke2hlaWdodEVsfXB4YFxyXG4gICAgICAgIH1cclxuICAgIH1cclxuXHJcbiAgICBjb25zdCB1cGRhdGUgPSAoKSA9PiB7XHJcbiAgICAgICAgZWwuc3R5bGUuaGVpZ2h0ID0gJ2F1dG8nXHJcbiAgICAgICAgc2V0VGltZW91dCgoKSA9PiB7XHJcbiAgICAgICAgICAgIGhlaWdodEVsID0gZWwub2Zmc2V0SGVpZ2h0XHJcbiAgICAgICAgICAgIGVsLnN0eWxlLmhlaWdodCA9IGAke2hlaWdodEVsfXB4YFxyXG4gICAgICAgIH0sIDEwMClcclxuICAgIH1cclxuXHJcbiAgICBidG4uYWRkRXZlbnRMaXN0ZW5lcignY2xpY2snLCAoKSA9PiB7XHJcbiAgICAgICAgaWYgKGVsLmNsYXNzTGlzdC5jb250YWlucygnbm90LWFjdGl2ZScpKSB7XHJcbiAgICAgICAgICAgIHJlbW92ZSgpXHJcbiAgICAgICAgICAgIGVsLnN0eWxlLmhlaWdodCA9IGAke2hlaWdodEVsfXB4YFxyXG4gICAgICAgIH0gZWxzZSB7XHJcbiAgICAgICAgICAgIGFkZCgpXHJcbiAgICAgICAgICAgIGVsLnN0eWxlLmhlaWdodCA9IGAke3N0YXJ0SGVpZ2h0fXB4YFxyXG4gICAgICAgIH1cclxuICAgIH0pXHJcblxyXG4gICAgbGV0IG9ic2VydmVyID0gbmV3IE11dGF0aW9uT2JzZXJ2ZXIobXV0YXRpb25SZWNvcmRzID0+IHtcclxuICAgICAgICB1cGRhdGUoKVxyXG4gICAgfSlcclxuXHJcbiAgICBvYnNlcnZlci5vYnNlcnZlKGVsLCB7XHJcbiAgICAgICAgY2hpbGRMaXN0OiB0cnVlLFxyXG4gICAgICAgIHN1YnRyZWU6IHRydWUsXHJcbiAgICAgICAgY2hhcmFjdGVyRGF0YU9sZFZhbHVlOiB0cnVlXHJcbiAgICB9KVxyXG59XHJcblxyXG5mdW5jdGlvbiBwYWdlKCkge1xyXG4gICAgY29uc3QgbWFpbiA9IGRvY3VtZW50LnF1ZXJ5U2VsZWN0b3IoJ1tkYXRhLXBhZ2U9XCJtYWluXCJdJylcclxuICAgIGNvbnN0IGhlYWRlciA9IGRvY3VtZW50LnF1ZXJ5U2VsZWN0b3IoJ1tkYXRhLWhlYWRlcj1cIm1haW5cIl0nKVxyXG5cclxuICAgIGlmICghbWFpbikgcmV0dXJuXHJcbiAgICBpZiAoIWhlYWRlcikgcmV0dXJuXHJcbiAgICBcclxuICAgIGNvbnN0IHdyYXBwZXJDb250ZW50ID0gbWFpbi5xdWVyeVNlbGVjdG9yKCdbZGF0YS1wYWdlPVwid3JhcHBlci1jb250ZW50XCJdJylcclxuXHJcbiAgICBpZiAod3JhcHBlckNvbnRlbnQpIHtcclxuICAgICAgICB3cmFwcGVyQ29udGVudC5zdHlsZS5wYWRkaW5nVG9wID0gYCR7aGVhZGVyLm9mZnNldEhlaWdodH1weGBcclxuICAgIH0gZWxzZSB7XHJcbiAgICAgICAgbWFpbi5zdHlsZS5wYWRkaW5nVG9wID0gYCR7aGVhZGVyLm9mZnNldEhlaWdodH1weGBcclxuICAgIH1cclxufVxyXG5cclxuZnVuY3Rpb24gaGVhZGVyKCkge1xyXG4gICAgY29uc3QgaGVhZGVyID0gZG9jdW1lbnQucXVlcnlTZWxlY3RvcignW2RhdGEtaGVhZGVyPVwibWFpblwiXScpXHJcblxyXG4gICAgaWYgKCFoZWFkZXIpIHJldHVyblxyXG5cclxuICAgIGNvbnN0IG1lbnUgPSBoZWFkZXIucXVlcnlTZWxlY3RvcignW2RhdGEtaGVhZGVyPVwibWVudVwiXScpXHJcbiAgICBjb25zdCBidG5NZW51ID0gaGVhZGVyLnF1ZXJ5U2VsZWN0b3IoJ1tkYXRhLWhlYWRlcj1cImJ0bi1tZW51XCJdJylcclxuICAgIGNvbnN0IG5hdlVsID0gaGVhZGVyLnF1ZXJ5U2VsZWN0b3IoJ1tkYXRhLWhlYWRlcj1cIm5hdi11bFwiXScpXHJcblxyXG4gICAgd2luZG93LmFkZEV2ZW50TGlzdGVuZXIoJ3Njcm9sbCcsIChldmVudCkgPT4ge1xyXG4gICAgICAgIGNvbnN0IHNjcm9sbGVkID0gd2luZG93LnBhZ2VZT2Zmc2V0ID8gd2luZG93LnBhZ2VZT2Zmc2V0IDogZG9jdW1lbnQuYm9keS5zY3JvbGxUb3A7XHJcblxyXG4gICAgICAgIGlmIChzY3JvbGxlZCA+PSAxMDApIHtcclxuICAgICAgICAgICAgaGVhZGVyLmNsYXNzTGlzdC5hZGQoJ2hlYWRlci0tZml4ZWQnKVxyXG4gICAgICAgIH0gZWxzZSB7XHJcbiAgICAgICAgICAgIGhlYWRlci5jbGFzc0xpc3QucmVtb3ZlKCdoZWFkZXItLWZpeGVkJylcclxuICAgICAgICB9XHJcbiAgICB9KVxyXG5cclxuICAgIGlmICh3aW5kb3cubWF0Y2hNZWRpYShcIihtYXgtd2lkdGg6IDk5MnB4KVwiKS5tYXRjaGVzKSB7XHJcbiAgICAgICAgYnRuTWVudS5hZGRFdmVudExpc3RlbmVyKCdjbGljaycsICgpID0+IHtcclxuICAgICAgICAgICAgYnRuTWVudS5jbGFzc0xpc3QudG9nZ2xlKCdhY3RpdmUnKVxyXG4gICAgICAgICAgICBtZW51LmNsYXNzTGlzdC50b2dnbGUoJ2FjdGl2ZScpXHJcbiAgICAgICAgfSlcclxuXHJcbiAgICAgICAgbmF2VWwuYWRkRXZlbnRMaXN0ZW5lcignY2xpY2snLCAoZXZlbnQpID0+IHtcclxuICAgICAgICAgICAgaWYgKGV2ZW50LnRhcmdldC5jbG9zZXN0KCdhJykpIHtcclxuICAgICAgICAgICAgICAgIGJ0bk1lbnUuY2xhc3NMaXN0LnJlbW92ZSgnYWN0aXZlJylcclxuICAgICAgICAgICAgICAgIG1lbnUuY2xhc3NMaXN0LnJlbW92ZSgnYWN0aXZlJylcclxuICAgICAgICAgICAgfVxyXG4gICAgICAgIH0pXHJcbiAgICB9XHJcbn1cclxuXHJcbmZ1bmN0aW9uIHByZXNlbnRhdGlvbigpIHtcclxuICAgIGNvbnN0IG1haW4gPSBkb2N1bWVudC5xdWVyeVNlbGVjdG9yKCdbZGF0YS1wcmVzZW50YXRpb249XCJtYWluXCJdJylcclxuXHJcbiAgICBpZiAoIW1haW4pIHJldHVyblxyXG5cclxuICAgIGNvbnN0IGJsb2NrUGFyYWxsYXggPSBtYWluLnF1ZXJ5U2VsZWN0b3IoJ1tkYXRhLXByZXNlbnRhdGlvbj1cImJsb2NrLXBhcmFsbGF4XCJdJylcclxuXHJcbiAgICBjb25zdCBwYXJhbGxheEluc3RhbmNlID0gbmV3IFBhcmFsbGF4KGJsb2NrUGFyYWxsYXgsIHtcclxuICAgICAgICBob3Zlck9ubHk6IHRydWVcclxuICAgIH0pXHJcbn1cclxuXHJcbmZ1bmN0aW9uIG1vZGFsUGljdHVyZSgpIHtcclxuXHJcbiAgICBjb25zdCBibG9ja1BpY3R1cmVzID0gZG9jdW1lbnQucXVlcnlTZWxlY3RvckFsbCgnW2RhdGEtbW9kYWwtcGljdHVyZT1cIm1haW5cIl0nKVxyXG5cclxuICAgIGlmICghYmxvY2tQaWN0dXJlcy5sZW5ndGgpIHJldHVyblxyXG5cclxuICAgIGxldCBicCA9IEJpZ2dlclBpY3R1cmUoe1xyXG4gICAgICAgIHRhcmdldDogZG9jdW1lbnQuYm9keSxcclxuICAgIH0pXHJcblxyXG4gICAgY29uc3Qgb3BlbkdhbGxlcnkgPSAoZXZlbnQsIHBpY3R1cmVzKSA9PiB7XHJcbiAgICAgICAgZXZlbnQucHJldmVudERlZmF1bHQoKVxyXG4gICAgICAgIGJwLm9wZW4oe1xyXG4gICAgICAgICAgICBpdGVtczogcGljdHVyZXMsXHJcbiAgICAgICAgICAgIGVsOiBldmVudC5jdXJyZW50VGFyZ2V0LFxyXG4gICAgICAgIH0pXHJcbiAgICB9XHJcblxyXG4gICAgYmxvY2tQaWN0dXJlcy5mb3JFYWNoKGJsb2NrUGljdHVyZSA9PiB7XHJcbiAgICAgICAgY29uc3QgcGljdHVyZXMgPSBibG9ja1BpY3R1cmUucXVlcnlTZWxlY3RvckFsbCgnYVtkYXRhLW1vZGFsLXBpY3R1cmU9XCJsaW5rXCJdJylcclxuXHJcbiAgICAgICAgaWYgKHBpY3R1cmVzLmxlbmd0aCkge1xyXG5cclxuICAgICAgICAgICAgcGljdHVyZXMuZm9yRWFjaChwaWN0dXJlID0+IHtcclxuICAgICAgICAgICAgICAgIGNvbnN0IGltYWdlID0gcGljdHVyZS5xdWVyeVNlbGVjdG9yKCdpbWcnKVxyXG4gICAgICAgICAgICAgICAgY29uc3QgaW1hZ2VTb3VyY2UgPSBpbWFnZS5nZXRBdHRyaWJ1dGUoJ3NyYycpXHJcbiAgICAgICAgICAgICAgICBjb25zdCBpbWcgPSBuZXcgSW1hZ2UoKVxyXG5cclxuICAgICAgICAgICAgICAgIGltZy5vbmxvYWQgPSBmdW5jdGlvbiAoKSB7XHJcbiAgICAgICAgICAgICAgICAgICAgY29uc3Qgd2lkdGggPSB0aGlzLndpZHRoXHJcbiAgICAgICAgICAgICAgICAgICAgY29uc3QgaGlnaHQgPSB0aGlzLmhlaWdodFxyXG5cclxuICAgICAgICAgICAgICAgICAgICBwaWN0dXJlLnNldEF0dHJpYnV0ZSgnZGF0YS1oZWlnaHQnLCBoaWdodCAqIDQpXHJcbiAgICAgICAgICAgICAgICAgICAgcGljdHVyZS5zZXRBdHRyaWJ1dGUoJ2RhdGEtd2lkdGgnLCB3aWR0aCAqIDQpXHJcbiAgICAgICAgICAgICAgICB9XHJcblxyXG4gICAgICAgICAgICAgICAgaW1nLnNyYyA9IGltYWdlU291cmNlO1xyXG5cclxuICAgICAgICAgICAgICAgIHBpY3R1cmUuYWRkRXZlbnRMaXN0ZW5lcihcImNsaWNrXCIsIChldmVudCkgPT4ge1xyXG4gICAgICAgICAgICAgICAgICAgIG9wZW5HYWxsZXJ5KGV2ZW50LCBwaWN0dXJlcylcclxuICAgICAgICAgICAgICAgIH0pXHJcbiAgICAgICAgICAgIH0pXHJcbiAgICAgICAgfVxyXG4gICAgfSlcclxufVxyXG5cclxuZnVuY3Rpb24gcHJvZ3JhbSgpIHtcclxuICAgIGNvbnN0IG1haW5zID0gZG9jdW1lbnQucXVlcnlTZWxlY3RvckFsbCgnW2RhdGEtcHJvZ3JhbT1cIm1haW5cIl0nKVxyXG5cclxuICAgIGlmICghbWFpbnMubGVuZ3RoKSByZXR1cm5cclxuXHJcbiAgICBtYWlucy5mb3JFYWNoKG1haW4gPT4ge1xyXG4gICAgICAgIGNvbnN0IHNsaWRlciA9IG1haW4ucXVlcnlTZWxlY3RvcignW2RhdGEtcHJvZ3JhbT1cInNsaWRlclwiXScpXHJcbiAgICAgICAgY29uc3QgYnRuUHJldiA9IG1haW4ucXVlcnlTZWxlY3RvcignW2RhdGEtcHJvZ3JhbT1cImJ0bi1wcmV2XCJdJylcclxuICAgICAgICBjb25zdCBidG5OZXh0ID0gbWFpbi5xdWVyeVNlbGVjdG9yKCdbZGF0YS1wcm9ncmFtPVwiYnRuLW5leHRcIl0nKVxyXG5cclxuICAgICAgICBjb25zdCBzd2lwZXIgPSBuZXcgU3dpcGVyKHNsaWRlciwge1xyXG4gICAgICAgICAgICBzcGFjZUJldHdlZW46IDIwLFxyXG4gICAgICAgICAgICBhdXRvSGVpZ2h0OiB0cnVlLFxyXG4gICAgICAgICAgICBuYXZpZ2F0aW9uOiB7XHJcbiAgICAgICAgICAgICAgbmV4dEVsOiBidG5OZXh0LFxyXG4gICAgICAgICAgICAgIHByZXZFbDogYnRuUHJldixcclxuICAgICAgICAgICAgfSxcclxuICAgICAgICB9KVxyXG4gICAgfSlcclxufVxyXG5cclxuZnVuY3Rpb24gcmV2aWV3cygpIHtcclxuICAgIGNvbnN0IG1haW5zID0gZG9jdW1lbnQucXVlcnlTZWxlY3RvckFsbCgnW2RhdGEtcmV2aWV3cz1cIm1haW5cIl0nKVxyXG5cclxuICAgIGlmICghbWFpbnMubGVuZ3RoKSByZXR1cm5cclxuXHJcbiAgICBtYWlucy5mb3JFYWNoKG1haW4gPT4ge1xyXG4gICAgICAgIGNvbnN0IHNsaWRlciA9IG1haW4ucXVlcnlTZWxlY3RvcignW2RhdGEtcmV2aWV3cz1cInNsaWRlclwiXScpXHJcbiAgICAgICAgY29uc3QgYnRuUHJldiA9IG1haW4ucXVlcnlTZWxlY3RvcignW2RhdGEtcmV2aWV3cz1cImJ0bi1wcmV2XCJdJylcclxuICAgICAgICBjb25zdCBidG5OZXh0ID0gbWFpbi5xdWVyeVNlbGVjdG9yKCdbZGF0YS1yZXZpZXdzPVwiYnRuLW5leHRcIl0nKVxyXG5cclxuICAgICAgICBjb25zdCBzd2lwZXIgPSBuZXcgU3dpcGVyKHNsaWRlciwge1xyXG4gICAgICAgICAgICBzbGlkZXNQZXJWaWV3OiAxLFxyXG4gICAgICAgICAgICBzcGFjZUJldHdlZW46IDIwLFxyXG4gICAgICAgICAgICBhdXRvSGVpZ2h0OiB0cnVlLFxyXG4gICAgICAgICAgICBuYXZpZ2F0aW9uOiB7XHJcbiAgICAgICAgICAgICAgbmV4dEVsOiBidG5OZXh0LFxyXG4gICAgICAgICAgICAgIHByZXZFbDogYnRuUHJldixcclxuICAgICAgICAgICAgfSxcclxuICAgICAgICAgICAgYnJlYWtwb2ludHM6IHtcclxuICAgICAgICAgICAgICAgIDk5Mjoge1xyXG4gICAgICAgICAgICAgICAgICBzbGlkZXNQZXJWaWV3OiAyLFxyXG4gICAgICAgICAgICAgICAgfSxcclxuICAgICAgICAgICAgfVxyXG4gICAgICAgIH0pXHJcbiAgICB9KVxyXG59XHJcblxyXG5mdW5jdGlvbiBzY3JvbGxQYXJhbGxheCgpIHtcclxuICAgIGNvbnN0IGl0ZW1zID0gZG9jdW1lbnQucXVlcnlTZWxlY3RvckFsbCgnW2RhdGEtc2Nyb2xsLXBhcmFsbGF4XScpXHJcblxyXG4gICAgaWYgKCFpdGVtcy5sZW5ndGgpIHJldHVyblxyXG5cclxuICAgIG5ldyBzaW1wbGVQYXJhbGxheChpdGVtcywge1xyXG4gICAgICAgIGRlbGF5OiAuMyxcclxuICAgICAgICBzY2FsZTogMS4yLFxyXG4gICAgICAgIHRyYW5zaXRpb246ICdjdWJpYy1iZXppZXIoMCwwLDAsMSknXHJcbiAgICB9KVxyXG59XHJcblxyXG5mdW5jdGlvbiBmYXEoKSB7XHJcbiAgICBjb25zdCBtYWlucyA9IGRvY3VtZW50LnF1ZXJ5U2VsZWN0b3JBbGwoJ1tkYXRhLWZhcT1cIm1haW5cIl0nKVxyXG5cclxuICAgIGlmICghbWFpbnMubGVuZ3RoKSByZXR1cm5cclxuXHJcbiAgICBtYWlucy5mb3JFYWNoKG1haW4gPT4ge1xyXG4gICAgICAgIGNvbnN0IGJsb2NrcyA9IG1haW4ucXVlcnlTZWxlY3RvckFsbCgnW2RhdGEtZmFxPVwiYmxvY2tcIl0nKVxyXG5cclxuICAgICAgICBibG9ja3MuZm9yRWFjaChibG9jayA9PiB7XHJcbiAgICAgICAgICAgIGNvbnN0IGhlYWQgPSBibG9jay5xdWVyeVNlbGVjdG9yKCdbZGF0YS1mYXE9XCJoZWFkXCJdJylcclxuICAgICAgICAgICAgY29uc3QgYm9keSA9IGJsb2NrLnF1ZXJ5U2VsZWN0b3IoJ1tkYXRhLWZhcT1cImJvZHlcIl0nKVxyXG5cclxuICAgICAgICAgICAgc21vb3RoVmlldyhoZWFkLCBib2R5KVxyXG4gICAgICAgIH0pXHJcbiAgICB9KVxyXG59XHJcblxyXG5mdW5jdGlvbiBzbW9vdGhTY3JvbGxpbmcoKSB7XHJcbiAgICBjb25zdCBhbmNob3JzID0gZG9jdW1lbnQucXVlcnlTZWxlY3RvckFsbCgnW2RhdGEtc21vb3RoLXNjcm9sbGluZyo9XCIjXCJdJylcclxuXHJcbiAgICBpZiAoIWFuY2hvcnMubGVuZ3RoKSByZXR1cm5cclxuXHJcbiAgICBkb2N1bWVudC5hZGRFdmVudExpc3RlbmVyKCdjbGljaycsIChldmVudCkgPT4ge1xyXG4gICAgICAgIGNvbnN0IGVsID0gZXZlbnQudGFyZ2V0XHJcblxyXG4gICAgICAgIGlmIChlbC5jbG9zZXN0KCdbZGF0YS1zbW9vdGgtc2Nyb2xsaW5nKj1cIiNcIl0nKSkge1xyXG4gICAgICAgICAgICBldmVudC5wcmV2ZW50RGVmYXVsdCgpXHJcbiAgICAgICAgICAgIGNvbnN0IGFuY2hvciA9IGVsLmNsb3Nlc3QoJ1tkYXRhLXNtb290aC1zY3JvbGxpbmcqPVwiI1wiXScpXHJcbiAgICAgICAgICAgIFxyXG4gICAgICAgICAgICBjb25zdCBibG9ja0lEID0gYW5jaG9yLmdldEF0dHJpYnV0ZSgnZGF0YS1zbW9vdGgtc2Nyb2xsaW5nJykuc3Vic3RyKDEpXHJcbiAgICAgICAgICAgIFxyXG4gICAgICAgICAgICBkb2N1bWVudC5xdWVyeVNlbGVjdG9yKGBbZGF0YS1zbW9vdGgtc2Nyb2xsaW5nPVwiJHtibG9ja0lEfVwiXWApLnNjcm9sbEludG9WaWV3KHtcclxuICAgICAgICAgICAgICAgIGJlaGF2aW9yOiAnc21vb3RoJyxcclxuICAgICAgICAgICAgICAgIGJsb2NrOiAnc3RhcnQnXHJcbiAgICAgICAgICAgIH0pXHJcbiAgICAgICAgfVxyXG4gICAgfSlcclxufVxyXG5cclxuZnVuY3Rpb24gcGhvbmVNYXNrKCkge1xyXG4gICAgY29uc3QgcGhvbmVNYXNrcyA9IGRvY3VtZW50LnF1ZXJ5U2VsZWN0b3JBbGwoJ1tkYXRhLXBob25lLW1hc2tdJylcclxuXHJcbiAgICBpZiAoIXBob25lTWFza3MubGVuZ3RoKSByZXR1cm5cclxuXHJcbiAgICBwaG9uZU1hc2tzLmZvckVhY2gocGhvbmVNYXNrID0+IHtcclxuICAgICAgICBJTWFzayhwaG9uZU1hc2ssIHtcclxuICAgICAgICAgICAgbWFzazogJyt7N30oMDAwKTAwMC0wMC0wMCdcclxuICAgICAgICB9KVxyXG4gICAgfSlcclxufVxyXG5cclxuZnVuY3Rpb24gc29ydGluZygpIHtcclxuICAgIGNvbnN0IG1haW5zID0gZG9jdW1lbnQucXVlcnlTZWxlY3RvckFsbCgnW2RhdGEtc29ydGluZz1cIm1haW5cIl0nKVxyXG5cclxuICAgIGlmICghbWFpbnMubGVuZ3RoKSByZXR1cm5cclxuXHJcbiAgICBkb2N1bWVudC5hZGRFdmVudExpc3RlbmVyKCdjbGljaycsIChldmVudCkgPT4ge1xyXG4gICAgICAgIGNvbnN0IGVsID0gZXZlbnQudGFyZ2V0XHJcbiAgICAgICAgaWYgKGVsLmNsb3Nlc3QoJ1tkYXRhLXNvcnRpbmc9XCJtYWluXCJdJykpIHtcclxuICAgICAgICAgICAgY29uc3Qgc29ydGluZyA9IGVsLmNsb3Nlc3QoJ1tkYXRhLXNvcnRpbmc9XCJtYWluXCJdJylcclxuXHJcbiAgICAgICAgICAgIG1haW5zLmZvckVhY2gobWFpbiA9PiB7XHJcbiAgICAgICAgICAgICAgICBpZiAobWFpbiAhPSBzb3J0aW5nKSB7XHJcbiAgICAgICAgICAgICAgICAgICAgbWFpbi5jbGFzc0xpc3QucmVtb3ZlKCdhY3RpdmUnKVxyXG4gICAgICAgICAgICAgICAgfVxyXG4gICAgICAgICAgICB9KVxyXG5cclxuICAgICAgICAgICAgaWYgKGVsLmNsb3Nlc3QoJ1tkYXRhLXNvcnRpbmc9XCJibG9jay1oZWFkXCJdJykpIHtcclxuICAgICAgICAgICAgICAgIHNvcnRpbmcuY2xhc3NMaXN0LnRvZ2dsZSgnYWN0aXZlJylcclxuICAgICAgICAgICAgfVxyXG5cclxuICAgICAgICAgICAgaWYgKGVsLmNsb3Nlc3QoJy5yYWRpbycpKSB7XHJcbiAgICAgICAgICAgICAgICBzb3J0aW5nLmNsYXNzTGlzdC5yZW1vdmUoJ2FjdGl2ZScpXHJcbiAgICAgICAgICAgIH1cclxuXHJcbiAgICAgICAgfSBlbHNlIHtcclxuICAgICAgICAgICAgbWFpbnMuZm9yRWFjaChtYWluID0+IG1haW4uY2xhc3NMaXN0LnJlbW92ZSgnYWN0aXZlJykpXHJcbiAgICAgICAgfVxyXG4gICAgfSlcclxufVxyXG5cclxuZnVuY3Rpb24gbW9kYWwoKSB7XHJcbiAgICByZXR1cm4gbmV3IEh5c3RNb2RhbCh7XHJcbiAgICAgICAgbGlua0F0dHJpYnV0ZU5hbWU6IFwiZGF0YS1oeXN0bW9kYWxcIixcclxuICAgICAgICB3YWl0VHJhbnNpdGlvbnM6IHRydWUsXHJcbiAgICB9KVxyXG59XHJcblxyXG5wYWdlKClcclxuaGVhZGVyKClcclxucHJlc2VudGF0aW9uKClcclxubW9kYWxQaWN0dXJlKClcclxucHJvZ3JhbSgpXHJcbnJldmlld3MoKVxyXG5zY3JvbGxQYXJhbGxheCgpXHJcbmZhcSgpXHJcbnBob25lTWFzaygpXHJcbnNtb290aFNjcm9sbGluZygpXHJcbnNvcnRpbmcoKVxyXG5tb2RhbCgpIl0sImZpbGUiOiJtYWluLmpzIn0=