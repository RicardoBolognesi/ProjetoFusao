import { Subject } from "rxjs";
import { RequestInfo } from "./models/request-info.model";

export class AppSettings {

  public static RequestInfoEvent: Subject<RequestInfo> = new Subject<RequestInfo>();
  public static IsLoginPageEvent: Subject<boolean> = new Subject<boolean>();
  public static IsAuthenticated: Subject<boolean> = new Subject<boolean>();

  ///TipoOperacao = 0 --> Insert
  ///TipoOperacao = 1 --> Read
  ///TipoOperacao = 2 --> Update
  ///TipoOperacao = 3 --> Delete

  public static TipoOperacao: Subject<number> = new Subject<number>();

  //APIs
  public static ACCOUNT_API = 'AccountAPI';
  public static ENDERECO_TIPO_API = 'EnderecoTipoAPI';
  public static ROLE_API = 'RoleAPI';
  public static USER_API = 'UserAPI';
  public static PRODUCT_API = 'ProductAPI';
  public static INFRASTRUCTURE_API = 'InfrastructureAPI';

  //API URLs
  public static SIGN_IN_URL = AppSettings.ACCOUNT_API + '/SignIn';
  public static SIGN_OUT_URL = AppSettings.ACCOUNT_API + '/SignOut';
  public static GET_SIGNED_IN_USER = AppSettings.ACCOUNT_API + '/GetSignedInUser';
  public static GET_USERNAME_URL = AppSettings.ACCOUNT_API + '/ObterNomeUsuario';

  public static GET_ALL_ROLES_URL = AppSettings.ROLE_API + '/GetAllRoles';
  public static SAVE_ROLE_URL = AppSettings.ROLE_API + '/SaveRole';
  public static GET_ALL_EMPLOYEES_URL = AppSettings.USER_API + '/GetAllUsers';
  public static SAVE_EMPLOYEE_URL = AppSettings.USER_API + '/SaveUser';
  public static GET_ALL_PRODUCTS_URL = AppSettings.PRODUCT_API + '/GetAllProducts';
  public static SAVE_PRODUCT_URL = AppSettings.PRODUCT_API + '/SaveProduct';
  public static GET_SERVER_INFO = AppSettings.INFRASTRUCTURE_API + '/GetRequestInfo';
  public static CREATE_ENDERECO_TIPO_URL = AppSettings.ENDERECO_TIPO_API + '/Create';
  public static EDIT_ENDERECO_TIPO_URL = AppSettings.ENDERECO_TIPO_API + '/Edit';
  public static DELETE_ENDERECO_TIPO_URL = AppSettings.ENDERECO_TIPO_API + '/Delete';
  public static GET_ALL_ENDERECO_TIPO_URL = AppSettings.ENDERECO_TIPO_API + '/GetAll';
  public static UPDATE_ENDERECO_TIPO_URL = AppSettings.ENDERECO_TIPO_API + '/Update';
}
