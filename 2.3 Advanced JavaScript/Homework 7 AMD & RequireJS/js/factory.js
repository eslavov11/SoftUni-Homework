define(['item','section','container'], function(Item, Section, Container) {
    return {
        createContainer : function(title) {
            return new Container(title);
        },
        createSection : function(title) {
            return new Section(title);
        },
        createItem : function(title, status) {
            return new Item(title, status);
        }
    }
});