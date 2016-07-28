namespace SkinApp.Services {

    export class UserService {
        private userResource;

        constructor($resource: angular.resource.IResourceService) {
            this.userResource = $resource('/api/user/:id', null, {
                //custom methods
                GetCurrentUser: {
                    method: 'GET',
                    url: '/api/user/getcurrentuser',
                },
                RemoveSkin: {
                    method: 'DELETE',
                    url: '/api/user/removeskin/:id'
                }
            });
        }
        //gets currently logged in user
        getCurrentUser() {
            return this.userResource.GetCurrentUser();
        }

        removeSkin(skinId) {
            debugger;
            return this.userResource.RemoveSkin(skinId).$promise;
        }
    }
    angular.module('SkinApp').service('userService', UserService);
}