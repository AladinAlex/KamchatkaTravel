let form = document.getElementById("#feedbackForm");
if (form != null) {
    form.addEventListener('submit', (event) => { event.preventDefault(); sendFeedback(); });
}
document.querySelector('[name="tours"]').addEventListener('click', (event) => { event.preventDefault(); mainTransit('tours'); });
document.querySelector('[name="about"]').addEventListener('click', (event) => { event.preventDefault(); mainTransit('about'); });
document.querySelector('[name="reviews"]').addEventListener('click', (event) => { event.preventDefault(); mainTransit('reviews'); });
scrollToBlock();

async function sendFeedback() {

    const FirstName = form.querySelector('[name="firstname"]'),
        Email = form.querySelector('[name="email"]'),
        Phone = form.querySelector('[name="phone"]');

    if (FirstName.value.length > 0
        && Email.value.length > 0
        && Phone.value.length > 0)
    {

        let searchParams = new URLSearchParams(window.location.search);
        let param, url;

        if (searchParams.has('tourId')) {
            param = searchParams.get('tourId');
            url = 'ClientRequest';
        }
        else {
            param = null;
            url = 'Home/ClientRequest';
        }

        var data = {
            FirstName: FirstName.value,
            Email: Email.value,
            Phone: Phone.value,
            TourId: param,
        };

        let responce = await fetch(url,
            {
                method: 'post',
                headers: {
                    'Content-Type': 'application/json;charset=utf-8'
                },
                body: JSON.stringify(data)
            }
        )

        let result = await responce.status;

        if (result == 200) {
            console.log(result);
            document.getElementById("#ModalTitle").innerHTML = 'Заявка отправлена!';
            document.getElementById("#ModalText").innerHTML = 'Мы свяжемся с вами в ближайшее время.';
            modal().open("#m-success");
        }
        else {
            console.log(503);
            document.getElementById("#ModalTitle").innerHTML = 'Ошибка!';
            document.getElementById("#ModalText").innerHTML = 'Сервер не отвечает, попробуйте позже.';

            modal().open("#m-success");
        }
    }
    else {
        console.log(400);
    }
}

function mainTransit(idSection) {

    if (window.location.pathname != "/") {
        window.location.href = "/#" + idSection;
    }
}

function scrollToBlock() {
    var hash = window.location.hash;
    //console.log(hash);
    if (hash != '') {
        document.querySelector(`[data-smooth-scrolling="${hash.substr(1)}"]`).scrollIntoView({
            behavior: 'smooth',
            block: 'start'
        });
    }
}

