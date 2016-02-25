(function() {
   require.config({
       paths: {
           'extensions' : 'helpers/extensions',
           'item' : 'models/item',
           'container' : 'models/container',
           'section' : 'models/section',
           'factory' : 'factory'
       }
   })
}());

require(['factory'], function(factory) {
    var f = factory.createContainer('Custom');
    f.addToDom('main');
    console.log(f.getSections());
});

