namespace SkinApp.Controllers {

    export class ReplyEditController {
        private postId;

        constructor(private skinServices: SkinApp.Services.SkinServices,
            private $stateParams: angular.ui.IStateParamsService) {
            this.postId = $stateParams["id"];
        }
        //this controller will contain the code for editing a reply, work in progress

    }
}