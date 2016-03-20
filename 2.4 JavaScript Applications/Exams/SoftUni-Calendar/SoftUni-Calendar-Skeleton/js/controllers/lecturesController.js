var app = app || {};

app.lecturesController = (function () {
    function LecturesController(viewBag, model, constants) {
        this.model = model;
        this.viewBag = viewBag;
        this.constants = constants;
    }

    LecturesController.prototype.loadAllLectures = function (selector) {
        var _this = this;
        this.model.getAllLectures()
            .then(function (data) {
                _this.viewBag.showAllLectures(selector, data);
            })
    };

    LecturesController.prototype.loadMyLectures = function (selector) {
        var _this = this;
        this.model.getMyLectures(sessionStorage['userId'])
            .then(function (data) {
                _this.viewBag.showMyLectures(selector, data);
            })
    };

    LecturesController.prototype.loadAddLecture = function (selector) {
        this.viewBag.showAddLecture(selector);
    };

    LecturesController.prototype.addLecture = function (data) {
        var result = {
            title: data.title,
            start: data.start,
            end: data.end,
            lecturer: sessionStorage['username']
        },
        _this = this;

        this.model.addLecture(result)
            .then(function (success) {
                app.notyInfoMessage(_this.constants.ADD_LECTURE_SUCCESS_MSG.format(success.title));
                Sammy(function() {
                    this.trigger('redirectUrl', {url: '#/calendar/my/'});
                })
            }, function (error) {
                app.notyErrorMessage(_this.constants.ADD_LECTURE_ERROR_MSG);
                Sammy(function() {
                    this.trigger('redirectUrl', {url: '#/calendar/add/'});
                })
            });
    };

    LecturesController.prototype.loadEditLecture = function (selector, id) {
        var _this = this;

        this.model.getLectureById(id)
            .then(function (data) {
                _this.viewBag.showEditLecture(selector, data);
            }).done();
    };

    LecturesController.prototype.editLecture = function (data) {
        var _this = this;

        data.lecturer = sessionStorage['username'];
        this.model.editLecture(data._id, data)
            .then(function (success) {
                app.notyInfoMessage(_this.constants.EDIT_LECTURE_SUCCESS_MSG.format(success.title));
            }, function (error) {
                app.notyErrorMessage(_this.constants.EDIT_LECTURE_ERROR_MSG);
            })
            .done(function () {
                Sammy(function() {
                    this.trigger('redirectUrl', {url: '#/calendar/my/'});
                });
            })
    };

    LecturesController.prototype.loadDeleteLecture = function (selector, id) {
        var _this = this;

        this.model.getLectureById(id)
            .then(function (data) {
                _this.viewBag.showDeleteLecture(selector, data);
            }).done();
    };

    LecturesController.prototype.deleteLecture = function (lectureId) {
        var _this = this;

        this.model.deleteLecture(lectureId)
            .then(function (success) {
                app.notyInfoMessage(_this.constants.DELETE_LECTURE_SUCCESS_MSG);
            },function (error) {
                app.notyErrorMessage(_this.constants.DELETE_LECTURE_ERROR_MSG);
            })
            .done(function () {
                Sammy(function() {
                    this.trigger('redirectUrl', {url: '#/calendar/my/'});
                });
            });
    };

    return {
        load: function (viewBag, model, constants) {
            return new LecturesController(viewBag, model, constants);
        }
    };
}());