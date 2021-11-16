var cs = {

    collapseBtns: HTMLCollection,

    clear: function () {
        console.clear();
    },

    consoleLog: function (msg) {
        console.log(msg);
    },

    focusElementById: function (id) {
        setTimeout(function () {
            var el = document.getElementById(id);
            if (el) el.focus();
        }, 500);
    },

    get: function (key) {
        var json = localStorage.getItem(key);

        if (json) return JSON.parse(json);
        return null;
    },

    getCookieConsent: function () {
        var acknowledged = this.get('COOKIE_CONSENT');
        if (acknowledged) return true;
        return false;
    },

    getMenuSetting: function (key) {
        var setting = localStorage.getItem(key);

        if (setting) return JSON.parse(setting);
        return false;
    },

    init: function () {
        //todo ASAP i don't think this actually grabs anything
        this.collapseBtns = document.getElementsByClassName('online-offline');
    },

    justifyTable: function () {
        var rights = document.querySelectorAll('[r]');

        for (var i = 0; i < rights.length; i++) {
            rights[i].classList.add('text-right');
        }
    },

    remove: function (key) {
        localStorage.removeItem(key);
    },

    save: function (key, obj) {
        localStorage.setItem(key, JSON.stringify(obj));
    },

    scrollBottom: function (delay) {
        if (delay) {
            setTimeout(function () {
                window.scrollTo(0, document.body.scrollHeight);
            }, delay);
        }
        else {
            setTimeout(function () {
                window.scrollTo(0, document.body.scrollHeight);
            }, 50);
        }
    },

    scrollTo: function (y, delay) {
        if (delay) {
            setTimeout(function () {
                window.scrollTo(0, y);
            }, delay);
        }
        else {
            setTimeout(function () {
                window.scrollTo(0, y);
            }, 50);
        }

    },

    scrollToElement: function (selector, delay) {
        if (delay) {
            setTimeout(function () {
                document.querySelector(selector).scrollIntoView();
            }, delay);
        }
        else {
            setTimeout(function () {
                document.querySelector(selector).scrollIntoView();
            }, 50);
        }
    },

    scrollTop: function (delay) {
        if (delay) {
            setTimeout(function () {
                window.scrollTo(0, 0);
            }, delay);
        }
        else {
            setTimeout(function () {
                window.scrollTo(0, 0);
            }, 50);
        }
    },

    setCookieConsent: function () {
        this.save('COOKIE_CONSENT', true);
    },

    setSelectAll: function (id) {
        var el = document.getElementById(id);

        if (el) {
            el.addEventListener('focus', function () {
                el.select();
            });
        }
    },

    setMenuSetting: function (key, setting) {
        localStorage.setItem(key, setting);
    },

    setOnlineStatus: function (online) {
        var collapseBtns = this.collapseBtns;
        if (collapseBtns) {

            for (let item of collapseBtns) {
                if (online) {
                    item.classList.remove('btn-outline-danger');
                    item.classList.add('btn-outline-success');
                    item.title = 'You are online';
                }
                else {
                    item.classList.remove('btn-outline-success');
                    item.classList.add('btn-outline-danger');
                    item.title = 'You are OFFLINE';
                }
            }
        }
    },
}

cs.init();

window.addEventListener('online', function () {
    cs.setOnlineStatus(true);
});

window.addEventListener('offline', function () {
    cs.setOnlineStatus(false);
});