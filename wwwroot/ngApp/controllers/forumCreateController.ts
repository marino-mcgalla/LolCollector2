namespace SkinApp.Controllers {

    export class ForumCreateController {

        public post;

        constructor(private skinServices: SkinApp.Services.SkinServices,
            private $state: angular.ui.IStateService, private accountService: SkinApp.Services.AccountService) {
            this.checkLogin(); //checks if the current user is logged in
        }
        // saves forum post 
        savePost() {
            console.log(this.post);
            debugger;
            this.skinServices.savePost(this.post).then(() => {
                this.$state.go("forum");
            });
        }
        //checks if the user is logged in, if so directs the user to the create forum post method, if not directs to the login page
        checkLogin() {
            var login = this.accountService.isLoggedIn();
            if (login) {
                this.$state.go("new");
            }
            else {
                this.$state.go("login")
            }
        }
        //returns the user to the forum page from the "create new post" page
        cancel() {
            this.$state.go("forum");
        }
    }
}
