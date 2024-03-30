import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { MatTableDataSource } from '@angular/material/table';
import { MatSort } from '@angular/material/sort';
import { MatPaginator } from '@angular/material/paginator';
import { environment } from 'src/environments/environment';
import { Base } from 'src/app/shared/Base.model';
import { BaseParameter } from './BaseParameter.model';
@Injectable({
    providedIn: 'root'
})
export class BaseService {

    DataSource: MatTableDataSource<any>;
    DisplayColumns: string[] = ['STT', 'ID', 'Code', 'Name', 'Note', 'ParentID', 'SortOrder', 'Active', 'Save'];
    DisplayColumnsMobile: string[] = ['STT'];

    FileToUpload: FileList
    BaseParameter!: BaseParameter;
    IsShowLoading: boolean = false;
    APIURL: string = environment.APIURL;


    List: Base[] | undefined;
    ListFilter: Base[] | undefined;
    FormData!: Base;
    Controller: string = "Base";

    constructor(public httpClient: HttpClient) {
        this.InitializationFormData();
    }
    InitializationFormData() {
        this.FormData = {
            Description: environment.TokenAPI,
        };
        this.BaseParameter = {
            SearchString: "",
            ParentID: environment.InitializationNumber,
            Token: environment.TokenAPI,
        };
        this.List = [];
        this.ListFilter = [];
    }
    Filter(searchString: string) {
        if (searchString.length > 0) {
            searchString = searchString.trim();
            searchString = searchString.toLocaleLowerCase();
            this.ListFilter = this.List.filter((item: any) =>
                item.Name.toLocaleLowerCase().indexOf(searchString) !== -1 || item.Code.toLocaleLowerCase().indexOf(searchString) !== -1);
        }
        else {
            this.ListFilter = this.List;
        }
    }
    SearchAllNotEmpty(sort: MatSort, paginator: MatPaginator) {
        if (this.BaseParameter.SearchString.length > 0) {
            this.BaseParameter.SearchString = this.BaseParameter.SearchString.trim();
            this.DataSource.filter = this.BaseParameter.SearchString.toLowerCase();
        }
        else {
            this.ComponentGetAllNotEmptyToListAsync(sort, paginator);
        }
    }
    SearchAll(sort: MatSort, paginator: MatPaginator) {
        if (this.BaseParameter.SearchString.length > 0) {
            this.BaseParameter.SearchString = this.BaseParameter.SearchString.trim();
            this.DataSource.filter = this.BaseParameter.SearchString.toLowerCase();
        }
        else {
            this.ComponentGetAllAndEmptyToListAsync(sort, paginator);
        }
    }
    SearchByParentIDNotEmpty(sort: MatSort, paginator: MatPaginator) {
        if (this.BaseParameter.SearchString.length > 0) {
            this.BaseParameter.SearchString = this.BaseParameter.SearchString.trim();
            this.DataSource.filter = this.BaseParameter.SearchString.toLowerCase();
        }
        else {
            this.ComponentGetByParentIDNotEmptyToListAsync(sort, paginator);
        }
    }
    SearchByParentID(sort: MatSort, paginator: MatPaginator) {
        if (this.BaseParameter.SearchString.length > 0) {
            this.BaseParameter.SearchString = this.BaseParameter.SearchString.trim();
            this.DataSource.filter = this.BaseParameter.SearchString.toLowerCase();
        }
        else {
            this.ComponentGetByParentIDAndEmptyToListAsync(sort, paginator);
        }
    }
    ComponentGetAllNotEmptyToListAsync(sort: MatSort, paginator: MatPaginator) {
        this.IsShowLoading = true;
        this.GetAllToListAsync().subscribe(
            res => {
                this.List = (res as any[]).sort((a, b) => (a.SortOrder > b.SortOrder ? 1 : -1));
                this.ListFilter = this.List;
                this.DataSource = new MatTableDataSource(this.List);
                this.DataSource.sort = sort;
                this.DataSource.paginator = paginator;
                this.IsShowLoading = false;
            },
            err => {
                this.IsShowLoading = false;
            }
        );
    }
    ComponentGetAllAndEmptyToListAsync(sort: MatSort, paginator: MatPaginator) {
        this.IsShowLoading = true;
        this.GetAllAndEmptyToListAsync().subscribe(
            res => {
                this.List = (res as any[]).sort((a, b) => (a.SortOrder > b.SortOrder ? 1 : -1));
                this.ListFilter = this.List.filter(item => item.ID > 0);
                this.DataSource = new MatTableDataSource(this.List);
                this.DataSource.sort = sort;
                this.DataSource.paginator = paginator;
                this.IsShowLoading = false;
            },
            err => {
                this.IsShowLoading = false;
            }
        );
    }
    ComponentGetByParentIDNotEmptyToListAsync(sort: MatSort, paginator: MatPaginator) {
        this.IsShowLoading = true;
        this.GetByParentIDToListAsync().subscribe(
            res => {
                this.List = (res as any[]).sort((a, b) => (a.SortOrder > b.SortOrder ? 1 : -1));
                this.ListFilter = this.List;
                this.DataSource = new MatTableDataSource(this.List);
                this.DataSource.sort = sort;
                this.DataSource.paginator = paginator;
                this.IsShowLoading = false;
            },
            err => {
                this.IsShowLoading = false;
            }
        );
    }
    ComponentGetByParentIDAndEmptyToListAsync(sort: MatSort, paginator: MatPaginator) {
        this.IsShowLoading = true;
        this.GetByParentIDAndEmptyToListAsync().subscribe(
            res => {
                this.List = (res as any[]).sort((a, b) => (a.SortOrder > b.SortOrder ? 1 : -1));
                this.ListFilter = this.List.filter(item => item.ID > 0);
                this.DataSource = new MatTableDataSource(this.List);
                this.DataSource.sort = sort;
                this.DataSource.paginator = paginator;
                this.IsShowLoading = false;
            },
            err => {
                this.IsShowLoading = false;
            }
        );
    }
    ComponentGetAllToListAsync() {
        this.IsShowLoading = true;
        this.GetAllToListAsync().subscribe(
            res => {
                this.List = (res as any[]).sort((a, b) => (a.SortOrder > b.SortOrder ? 1 : -1));
                this.ListFilter = this.List;
                this.IsShowLoading = false;
            },
            err => {
                this.IsShowLoading = false;
            }
        );
    }
    ComponentGetByActiveToListAsync() {
        this.IsShowLoading = true;
        this.GetByActiveToListAsync().subscribe(
            res => {
                this.List = (res as any[]).sort((a, b) => (a.SortOrder > b.SortOrder ? 1 : -1));
                this.ListFilter = this.List;
                this.IsShowLoading = false;
            },
            err => {
                this.IsShowLoading = false;
            }
        );
    }
    ComponentGetByParentIDToListAsync() {
        this.IsShowLoading = true;
        this.GetByParentIDToListAsync().subscribe(
            res => {
                this.List = (res as any[]).sort((a, b) => (a.SortOrder > b.SortOrder ? 1 : -1));
                this.ListFilter = this.List;
                this.IsShowLoading = false;
            },
            err => {
                this.IsShowLoading = false;
            }
        );
    }
    ComponentSaveForm() {
        this.IsShowLoading = true;
        this.SaveAsync().subscribe(
            res => {
                this.FormData = res as any;
                this.IsShowLoading = false;
                return environment.SaveSuccess;
            },
            err => {
                this.IsShowLoading = false;
                return environment.SaveNotSuccess;
            }
        );
        return environment.SaveSuccess;
    }
    ComponentSaveAll(sort: MatSort, paginator: MatPaginator) {
        this.IsShowLoading = true;
        this.SaveAsync().subscribe(
            res => {
                this.SearchAll(sort, paginator);
                this.IsShowLoading = false;
                return environment.SaveSuccess;
            },
            err => {
                this.IsShowLoading = false;
                return environment.SaveNotSuccess;
            }
        );
        return environment.SaveSuccess;
    }
    ComponentSaveAllNotEmpty(sort: MatSort, paginator: MatPaginator) {
        this.IsShowLoading = true;
        this.SaveAsync().subscribe(
            res => {
                this.SearchAllNotEmpty(sort, paginator);
                this.IsShowLoading = false;
                return environment.SaveSuccess;
            },
            err => {
                this.IsShowLoading = false;
                return environment.SaveNotSuccess;
            }
        );
        return environment.SaveSuccess;
    }
    ComponentSaveByParentID(sort: MatSort, paginator: MatPaginator) {
        this.IsShowLoading = true;
        this.SaveAsync().subscribe(
            res => {
                this.SearchByParentID(sort, paginator);
                this.IsShowLoading = false;
                return environment.SaveSuccess;
            },
            err => {
                this.IsShowLoading = false;
                return environment.SaveNotSuccess;
            }
        );
        return environment.SaveSuccess;
    }
    ComponentSaveByParentIDNotEmpty(sort: MatSort, paginator: MatPaginator) {
        this.IsShowLoading = true;
        this.SaveAsync().subscribe(
            res => {
                this.SearchByParentIDNotEmpty(sort, paginator);
                this.IsShowLoading = false;
                return environment.SaveSuccess;
            },
            err => {
                this.IsShowLoading = false;
                return environment.SaveNotSuccess;
            }
        );
        return environment.SaveSuccess;
    }
    ComponentDeleteAll(sort: MatSort, paginator: MatPaginator) {
        if (confirm(environment.DeleteConfirm)) {
            this.IsShowLoading = true;
            this.RemoveAsync().subscribe(
                res => {
                    this.SearchAll(sort, paginator);
                    this.IsShowLoading = false;
                    return environment.SaveSuccess;
                },
                err => {
                    this.IsShowLoading = false;
                    return environment.SaveNotSuccess;
                }
            );
            return environment.SaveSuccess;
        }
    }
    ComponentDeleteAllNotEmpty(sort: MatSort, paginator: MatPaginator) {
        if (confirm(environment.DeleteConfirm)) {
            this.IsShowLoading = true;
            this.RemoveAsync().subscribe(
                res => {
                    this.SearchAllNotEmpty(sort, paginator);
                    this.IsShowLoading = false;
                    return environment.SaveSuccess;
                },
                err => {
                    this.IsShowLoading = false;
                    return environment.SaveNotSuccess;
                }
            );
            return environment.SaveSuccess;
        }
    }
    ComponentDeleteByParentID(sort: MatSort, paginator: MatPaginator) {
        if (confirm(environment.DeleteConfirm)) {
            this.IsShowLoading = true;
            this.RemoveAsync().subscribe(
                res => {
                    this.SearchByParentID(sort, paginator);
                    this.IsShowLoading = false;
                    return environment.SaveSuccess;
                },
                err => {
                    this.IsShowLoading = false;
                    return environment.SaveNotSuccess;
                }
            );
            return environment.SaveSuccess;
        }
    }
    ComponentDeleteByParentIDNotEmpty(sort: MatSort, paginator: MatPaginator) {
        if (confirm(environment.DeleteConfirm)) {
            this.IsShowLoading = true;
            this.RemoveAsync().subscribe(
                res => {
                    this.SearchByParentIDNotEmpty(sort, paginator);
                    this.IsShowLoading = false;
                    return environment.SaveSuccess;
                },
                err => {
                    this.IsShowLoading = false;
                    return environment.SaveNotSuccess;
                }
            );
            return environment.SaveSuccess;
        }
    }
    SaveList() {
        let url = this.APIURL + this.Controller + '/SaveList';
        const formUpload: FormData = new FormData();
        formUpload.append('data', JSON.stringify(this.List));
        return this.httpClient.post(url, formUpload);
    }
    SaveListAsync() {
        let url = this.APIURL + this.Controller + '/SaveListAsync';
        const formUpload: FormData = new FormData();
        formUpload.append('data', JSON.stringify(this.List));
        return this.httpClient.post(url, formUpload);
    }
    Save() {
        var lastUpdatedMembershipID = localStorage.getItem(environment.NhanVienID);
        if (lastUpdatedMembershipID) {
            this.FormData.LastUpdatedMembershipID = Number(lastUpdatedMembershipID);
        }
        let url = this.APIURL + this.Controller + '/Save';
        const formUpload: FormData = new FormData();
        formUpload.append('data', JSON.stringify(this.FormData));
        return this.httpClient.post(url, formUpload);
    }
    SaveAsync() {
        var lastUpdatedMembershipID = localStorage.getItem(environment.NhanVienID);
        if (lastUpdatedMembershipID) {
            this.FormData.LastUpdatedMembershipID = Number(lastUpdatedMembershipID);
        }
        let url = this.APIURL + this.Controller + '/SaveAsync';
        const formUpload: FormData = new FormData();
        formUpload.append('data', JSON.stringify(this.FormData));
        return this.httpClient.post(url, formUpload);
    }
    Remove() {
        let url = this.APIURL + this.Controller + '/Remove';
        const formUpload: FormData = new FormData();
        formUpload.append('data', JSON.stringify(this.BaseParameter));
        return this.httpClient.post(url, formUpload);
    }
    RemoveAsync() {
        let url = this.APIURL + this.Controller + '/RemoveAsync';
        const formUpload: FormData = new FormData();
        formUpload.append('data', JSON.stringify(this.BaseParameter));
        return this.httpClient.post(url, formUpload);
    }
    GetByID() {
        let url = this.APIURL + this.Controller + '/GetByID';
        const formUpload: FormData = new FormData();
        formUpload.append('data', JSON.stringify(this.BaseParameter));
        return this.httpClient.post(url, formUpload);
    }
    GetByIDAsync() {
        let url = this.APIURL + this.Controller + '/GetByIDAsync';
        const formUpload: FormData = new FormData();
        formUpload.append('data', JSON.stringify(this.BaseParameter));
        return this.httpClient.post(url, formUpload);
    }
    GetAllToList() {
        let url = this.APIURL + this.Controller + '/GetAllToList';
        const formUpload: FormData = new FormData();
        formUpload.append('data', JSON.stringify(this.BaseParameter));
        return this.httpClient.post(url, formUpload);
    }
    GetAllToListAsync() {
        let url = this.APIURL + this.Controller + '/GetAllToListAsync';        
        const formUpload: FormData = new FormData();
        formUpload.append('data', JSON.stringify(this.BaseParameter));
        return this.httpClient.post(url, formUpload);
    }
    GetAllAndEmptyToList() {
        let url = this.APIURL + this.Controller + '/GetAllAndEmptyToList';
        const formUpload: FormData = new FormData();
        formUpload.append('data', JSON.stringify(this.BaseParameter));
        return this.httpClient.post(url, formUpload);
    }
    GetAllAndEmptyToListAsync() {
        let url = this.APIURL + this.Controller + '/GetAllAndEmptyToListAsync';
        const formUpload: FormData = new FormData();
        formUpload.append('data', JSON.stringify(this.BaseParameter));
        return this.httpClient.post(url, formUpload);
    }
    GetByActiveToList() {
        let url = this.APIURL + this.Controller + '/GetByActiveToList';
        const formUpload: FormData = new FormData();
        formUpload.append('data', JSON.stringify(this.BaseParameter));
        return this.httpClient.post(url, formUpload);
    }
    GetByActiveToListAsync() {
        let url = this.APIURL + this.Controller + '/GetByActiveToListAsync';
        const formUpload: FormData = new FormData();
        formUpload.append('data', JSON.stringify(this.BaseParameter));
        return this.httpClient.post(url, formUpload);
    }
    GetByParentIDToList() {
        let url = this.APIURL + this.Controller + '/GetByParentIDToList';
        const formUpload: FormData = new FormData();
        formUpload.append('data', JSON.stringify(this.BaseParameter));
        return this.httpClient.post(url, formUpload);
    }
    GetByParentIDToListAsync() {
        let url = this.APIURL + this.Controller + '/GetByParentIDToListAsync';
        const formUpload: FormData = new FormData();
        formUpload.append('data', JSON.stringify(this.BaseParameter));
        return this.httpClient.post(url, formUpload);
    }
    GetByParentIDAndEmptyToList() {
        let url = this.APIURL + this.Controller + '/GetByParentIDAndEmptyToList';
        const formUpload: FormData = new FormData();
        formUpload.append('data', JSON.stringify(this.BaseParameter));
        return this.httpClient.post(url, formUpload);
    }
    GetByParentIDAndEmptyToListAsync() {
        let url = this.APIURL + this.Controller + '/GetByParentIDAndEmptyToListAsync';
        const formUpload: FormData = new FormData();
        formUpload.append('data', JSON.stringify(this.BaseParameter));
        return this.httpClient.post(url, formUpload);
    }
    GetByParentIDAndActiveToList() {
        let url = this.APIURL + this.Controller + '/GetByParentIDAndActiveToList';
        const formUpload: FormData = new FormData();
        formUpload.append('data', JSON.stringify(this.BaseParameter));
        return this.httpClient.post(url, formUpload);
    }
    GetByParentIDAndActiveToListAsync() {
        let url = this.APIURL + this.Controller + '/GetByParentIDAndActiveToListAsync';
        const formUpload: FormData = new FormData();
        formUpload.append('data', JSON.stringify(this.BaseParameter));
        return this.httpClient.post(url, formUpload);
    }
}

