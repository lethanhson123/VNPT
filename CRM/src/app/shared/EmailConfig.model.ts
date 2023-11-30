import { Base } from "./Base.model";

export class EmailConfig extends Base{     
    MasterEmailUser?: string;   
    MasterEmailPassword?: string;   
    MasterEmailDisplay?: string;   
    SMTPServer?: string;   
    SMTPPort?: number;   
    IsMailUsingSSL?: boolean;   
    IsMailBodyHtml?: boolean;       
}
