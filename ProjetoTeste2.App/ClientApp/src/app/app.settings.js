"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
var rxjs_1 = require("rxjs");
var AppSettings = /** @class */ (function () {
    function AppSettings() {
    }
    AppSettings.RequestInfoEvent = new rxjs_1.Subject();
    AppSettings.IsLoginPageEvent = new rxjs_1.Subject();
    AppSettings.IsAuthenticated = new rxjs_1.Subject();
    ///TipoOperacao = 0 --> Insert
    ///TipoOperacao = 1 --> Read
    ///TipoOperacao = 2 --> Update
    ///TipoOperacao = 3 --> Delete
    AppSettings.TipoOperacao = new rxjs_1.Subject();
    //APIs
    AppSettings.ACCOUNT_API = 'AccountAPI';
    AppSettings.ENDERECO_TIPO_API = 'EnderecoTipoAPI';
    AppSettings.ROLE_API = 'RoleAPI';
    AppSettings.USER_API = 'UserAPI';
    AppSettings.PRODUCT_API = 'ProductAPI';
    AppSettings.INFRASTRUCTURE_API = 'InfrastructureAPI';
    //API URLs
    AppSettings.SIGN_IN_URL = AppSettings.ACCOUNT_API + '/SignIn';
    AppSettings.SIGN_OUT_URL = AppSettings.ACCOUNT_API + '/SignOut';
    AppSettings.GET_SIGNED_IN_USER = AppSettings.ACCOUNT_API + '/GetSignedInUser';
    AppSettings.GET_USERNAME_URL = AppSettings.ACCOUNT_API + '/ObterNomeUsuario';
    AppSettings.GET_ALL_ROLES_URL = AppSettings.ROLE_API + '/GetAllRoles';
    AppSettings.SAVE_ROLE_URL = AppSettings.ROLE_API + '/SaveRole';
    AppSettings.GET_ALL_EMPLOYEES_URL = AppSettings.USER_API + '/GetAllUsers';
    AppSettings.SAVE_EMPLOYEE_URL = AppSettings.USER_API + '/SaveUser';
    AppSettings.GET_ALL_PRODUCTS_URL = AppSettings.PRODUCT_API + '/GetAllProducts';
    AppSettings.SAVE_PRODUCT_URL = AppSettings.PRODUCT_API + '/SaveProduct';
    AppSettings.GET_SERVER_INFO = AppSettings.INFRASTRUCTURE_API + '/GetRequestInfo';
    AppSettings.CREATE_ENDERECO_TIPO_URL = AppSettings.ENDERECO_TIPO_API + '/Create';
    AppSettings.EDIT_ENDERECO_TIPO_URL = AppSettings.ENDERECO_TIPO_API + '/Edit';
    AppSettings.DELETE_ENDERECO_TIPO_URL = AppSettings.ENDERECO_TIPO_API + '/Delete';
    AppSettings.GET_ALL_ENDERECO_TIPO_URL = AppSettings.ENDERECO_TIPO_API + '/GetAll';
    AppSettings.UPDATE_ENDERECO_TIPO_URL = AppSettings.ENDERECO_TIPO_API + '/Update';
    return AppSettings;
}());
exports.AppSettings = AppSettings;
//# sourceMappingURL=app.settings.js.map