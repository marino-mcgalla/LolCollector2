namespace SkinApp.Controllers {

    export class BuildController {
        public champions;
        public user;
        public skins = [];

        constructor (
            private $http: angular.IHttpService,
            private skinServices: SkinApp.Services.SkinServices,
            private $state: angular.ui.IStateService
        )
        {
            this.user = this.skinServices.getCurrentUser(); //gets user that is currently logged in, if any
            this.getChampions(); //makes a call to Riot's API for a list of champions
        }

        //gets a list of champions from Riot API
        getChampions() {
            this.$http.get("https://global.api.pvp.net/api/lol/static-data/na/v1.2/champion?champData=skins&api_key=3b03777b-7555-4f2d-820f-f9d704c71fdc").then((data: any) => {
                this.champions = data;
            });
        }

        //gets all skins selected by the user and then saves them to their profile
        checkSkins() {
            var selected = this.skins;
            $("input:checkbox[name=skinCheck]:checked").each(function () {
                selected.push($(this).val());
            });
            this.saveSkins();
        }

        //saves selected skins to user profile and then directs to the user's profile page for viewing
        saveSkins() {
            this.skinServices.saveSkins(this.user.id, this.skins).then(() => {
                this.$state.go("profile");
            });
        }
    }
}
