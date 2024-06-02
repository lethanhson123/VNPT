import { Base } from "./Base.model";

export class EmailLichSu extends Base{     
    EmailFrom?: string;           
    EmailTo?: string;         
    HTMLContent?: string;         
    DateSend?: Date;         
    DateRead?: Date;         
    IsSend?: boolean;         
    IsRead?: boolean;         
}
