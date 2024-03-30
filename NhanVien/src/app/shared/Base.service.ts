import { Injectable, ViewChild } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { MatTableDataSource } from '@angular/material/table';
import { MatSort } from '@angular/material/sort';
import { MatPaginator } from '@angular/material/paginator';
import { environment } from 'src/environments/environment';
import { NotificationService } from 'src/app/shared/Notification.service';
import { Base } from 'src/app/shared/Base.model';
import { BaseParameter } from './BaseParameter.model';
@Injectable({
    providedIn: 'root'
})
export class BaseService {

    DataSource: MatTableDataSource<any>;
    displayColumns: string[] = ['STT', 'ID', 'ParentID', 'Code', 'Name', 'Note', 'SortOrder', 'Active', 'Save'];
    list000: Base[] | undefined;
    list: Base[] | undefined;
    list001: Base[] | undefined;
    formData!: Base;
    fileToUpload: FileList
    baseParameter!: BaseParameter;
    SearchString: string = environment.InitializationString;
    IsShowLoading: boolean = false;
    aPIURL: string = environment.APIURL;
    controller: string = "Base";
    constructor(
        public httpClient: HttpClient
    ) {
        this.initializationFormData();
    }
    initializationFormData() {
        this.formData = {
        };
        this.baseParameter = {
            SearchString: ""
        };
        this.list = [];
        this.list000 = [];
        this.list001 = [];
    }

    Filter(searchString: string) {
        if (searchString.length > 0) {
            searchString = searchString.toLocaleLowerCase();
            this.list001 = this.list.filter((item: any) =>
                item.Name.toLocaleLowerCase().indexOf(searchString) !== -1 || item.Code.toLocaleLowerCase().indexOf(searchString) !== -1);
        }
        else {
            this.list001 = this.list;
        }
    }
    SearchAllNotEmpty(sort: MatSort, paginator: MatPaginator) {
        if (this.SearchString.length > 0) {
            this.DataSource.filter = this.SearchString.toLowerCase();
        }
        else {
            this.ComponentGetAllNotEmptyToListAsync(sort, paginator);
        }
    }
    SearchAll(sort: MatSort, paginator: MatPaginator) {
        if (this.SearchString.length > 0) {
            this.DataSource.filter = this.SearchString.toLowerCase();
        }
        else {
            this.ComponentGetAllAndEmptyToListAsync(sort, paginator);
        }
    }
    SearchBySearchString(sort: MatSort, paginator: MatPaginator) {
        this.ComponentGetBySearchStringAndEmptyToListAsync(sort, paginator);
    }
    SearchByParentID(sort: MatSort, paginator: MatPaginator) {
        if (this.SearchString.length > 0) {
            this.DataSource.filter = this.SearchString.toLowerCase();
        }
        else {
            this.ComponentGetByParentIDAndEmptyToListAsync(sort, paginator);
        }
    }
    SearchByParentIDAndActive(sort: MatSort, paginator: MatPaginator) {
        if (this.SearchString.length > 0) {
            this.DataSource.filter = this.SearchString.toLowerCase();
        }
        else {
            this.ComponentGetByParentIDAndActiveAndEmptyToListAsync(sort, paginator);
        }
    }
    ComponentGetAllNotEmptyToListAsync(sort: MatSort, paginator: MatPaginator) {
        this.IsShowLoading = true;
        this.GetAllToListAsync().subscribe(
            res => {
                this.list = (res as any[]).sort((a, b) => (a.SortOrder > b.SortOrder ? 1 : -1));
                this.list001 = this.list;
                this.DataSource = new MatTableDataSource(this.list);
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
                this.list = (res as any[]).sort((a, b) => (a.SortOrder > b.SortOrder ? 1 : -1));
                this.DataSource = new MatTableDataSource(this.list);
                this.DataSource.sort = sort;
                this.DataSource.paginator = paginator;
                this.IsShowLoading = false;
            },
            err => {
                this.IsShowLoading = false;
            }
        );
        this.GetAllToListAsync().subscribe(
            res => {
                this.list001 = (res as any[]).sort((a, b) => (a.SortOrder > b.SortOrder ? 1 : -1));
            },
            err => {
            }
        );
    }
    ComponentGetBySearchStringAndEmptyToListAsync(sort: MatSort, paginator: MatPaginator) {
        this.IsShowLoading = true;
        this.GetBySearchStringAndEmptyToListAsync().subscribe(
            res => {
                this.list = (res as any[]).sort((a, b) => (a.SortOrder > b.SortOrder ? 1 : -1));
                this.DataSource = new MatTableDataSource(this.list);
                this.DataSource.sort = sort;
                this.DataSource.paginator = paginator;
                this.IsShowLoading = false;
            },
            err => {
                this.IsShowLoading = false;
            }
        );
        this.GetBySearchStringToListAsync().subscribe(
            res => {
                this.list001 = (res as any[]).sort((a, b) => (a.SortOrder > b.SortOrder ? 1 : -1));
            },
            err => {
            }
        );
    }
    ComponentGetByParentIDAndEmptyToListAsync(sort: MatSort, paginator: MatPaginator) {
        this.IsShowLoading = true;
        this.GetByParentIDAndEmptyToListAsync().subscribe(
            res => {
                this.list = (res as any[]).sort((a, b) => (a.SortOrder > b.SortOrder ? 1 : -1));
                this.DataSource = new MatTableDataSource(this.list);
                this.DataSource.sort = sort;
                this.DataSource.paginator = paginator;
                this.IsShowLoading = false;
            },
            err => {
                this.IsShowLoading = false;
            }
        );
        this.GetByParentIDToListAsync().subscribe(
            res => {
                this.list001 = (res as any[]).sort((a, b) => (a.SortOrder > b.SortOrder ? 1 : -1));
            },
            err => {
            }
        );
    }
    ComponentGetByParentIDAndActiveAndEmptyToListAsync(sort: MatSort, paginator: MatPaginator) {
        this.IsShowLoading = true;
        this.GetByParentIDAndActiveAndEmptyToListAsync().subscribe(
            res => {
                this.list = (res as any[]).sort((a, b) => (a.SortOrder > b.SortOrder ? 1 : -1));
                this.DataSource = new MatTableDataSource(this.list);
                this.DataSource.sort = sort;
                this.DataSource.paginator = paginator;
                this.IsShowLoading = false;
            },
            err => {
                this.IsShowLoading = false;
            }
        );
        this.GetByParentIDAndActiveToListAsync().subscribe(
            res => {
                this.list001 = (res as any[]).sort((a, b) => (a.SortOrder > b.SortOrder ? 1 : -1));
            },
            err => {
            }
        );
    }
    ComponentGetAllToListAsync() {
        this.GetAllToListAsync().subscribe(
            res => {
                this.list = (res as any[]).sort((a, b) => (a.SortOrder > b.SortOrder ? 1 : -1));
                this.list001 = this.list;
            },
            err => {
            }
        );
    }
    ComponentGetByActiveToListAsync() {
        this.GetByActiveToListAsync().subscribe(
            res => {
                this.list = (res as any[]).sort((a, b) => (a.SortOrder > b.SortOrder ? 1 : -1));
                this.list001 = this.list;
            },
            err => {
            }
        );
    }
    ComponentGetByParentIDToListAsync() {
        this.GetByParentIDToListAsync().subscribe(
            res => {
                this.list = (res as any[]).sort((a, b) => (a.SortOrder > b.SortOrder ? 1 : -1));
                this.list001 = this.list;
            },
            err => {
            }
        );
    }
    ComponentSaveForm() {
        this.SaveAsync().subscribe(
            res => {
                this.formData = res as any;
                return environment.SaveSuccess;
            },
            err => {
                return environment.SaveNotSuccess;
            }
        );
        return environment.SaveSuccess;
    }
    ComponentSaveAll(sort: MatSort, paginator: MatPaginator) {
        this.SaveAsync().subscribe(
            res => {
                this.SearchAll(sort, paginator);
                return environment.SaveSuccess;
            },
            err => {
                return environment.SaveNotSuccess;
            }
        );
        return environment.SaveSuccess;
    }
    ComponentSaveByParentID(sort: MatSort, paginator: MatPaginator) {
        this.SaveAsync().subscribe(
            res => {
                this.SearchByParentID(sort, paginator);
                return environment.SaveSuccess;
            },
            err => {
                return environment.SaveNotSuccess;
            }
        );
        return environment.SaveSuccess;
    }
    ComponentSaveBySearchString(sort: MatSort, paginator: MatPaginator) {
        this.SaveAsync().subscribe(
            res => {
                this.SearchBySearchString(sort, paginator);
                return environment.SaveSuccess;
            },
            err => {
                return environment.SaveNotSuccess;
            }
        );
        return environment.SaveSuccess;
    }
    ComponentDeleteAll(sort: MatSort, paginator: MatPaginator) {
        if (confirm(environment.DeleteConfirm)) {
            this.RemoveAsync().subscribe(
                res => {
                    this.SearchAll(sort, paginator);
                    return environment.SaveSuccess;
                },
                err => {
                    return environment.SaveNotSuccess;
                }
            );
            return environment.SaveSuccess;
        }
    }
    ComponentDeleteByParentID(sort: MatSort, paginator: MatPaginator) {
        if (confirm(environment.DeleteConfirm)) {
            this.RemoveAsync().subscribe(
                res => {
                    this.SearchByParentID(sort, paginator);
                    return environment.SaveSuccess;
                },
                err => {
                    return environment.SaveNotSuccess;
                }
            );
            return environment.SaveSuccess;
        }
    }
    ComponentDeleteBySearchString(sort: MatSort, paginator: MatPaginator) {
        if (confirm(environment.DeleteConfirm)) {
            this.RemoveAsync().subscribe(
                res => {
                    this.SearchBySearchString(sort, paginator);
                    return environment.SaveSuccess;
                },
                err => {
                    return environment.SaveNotSuccess;
                }
            );
            return environment.SaveSuccess;
        }
    }

    Save() {
        var lastUpdatedMembershipID = localStorage.getItem(environment.ThanhVienID);
        if (lastUpdatedMembershipID) {
            this.formData.LastUpdatedMembershipID = Number(lastUpdatedMembershipID);
        }
        let url = this.aPIURL + this.controller + '/Save';
        const formUpload: FormData = new FormData();
        formUpload.append('data', JSON.stringify(this.formData));
        return this.httpClient.post(url, formUpload);
    }
    SaveAsync() {
        var lastUpdatedMembershipID = localStorage.getItem(environment.ThanhVienID);
        if (lastUpdatedMembershipID) {
            this.formData.LastUpdatedMembershipID = Number(lastUpdatedMembershipID);
        }
        let url = this.aPIURL + this.controller + '/SaveAsync';
        const formUpload: FormData = new FormData();
        formUpload.append('data', JSON.stringify(this.formData));
        return this.httpClient.post(url, formUpload);
    }
    Remove() {
        let url = this.aPIURL + this.controller + '/Remove';
        const formUpload: FormData = new FormData();
        formUpload.append('data', JSON.stringify(this.baseParameter));
        return this.httpClient.post(url, formUpload);
    }
    RemoveAsync() {
        let url = this.aPIURL + this.controller + '/RemoveAsync';
        const formUpload: FormData = new FormData();
        formUpload.append('data', JSON.stringify(this.baseParameter));
        return this.httpClient.post(url, formUpload);
    }
    GetByID() {
        let url = this.aPIURL + this.controller + '/GetByID';
        const formUpload: FormData = new FormData();
        formUpload.append('data', JSON.stringify(this.baseParameter));
        return this.httpClient.post(url, formUpload);
    }
    GetByIDAsync() {
        let url = this.aPIURL + this.controller + '/GetByIDAsync';
        const formUpload: FormData = new FormData();
        formUpload.append('data', JSON.stringify(this.baseParameter));
        return this.httpClient.post(url, formUpload);
    }
    GetByName() {
        let url = this.aPIURL + this.controller + '/GetByName';
        const formUpload: FormData = new FormData();
        formUpload.append('data', JSON.stringify(this.baseParameter));
        return this.httpClient.post(url, formUpload);
    }
    GetByNameAsync() {
        let url = this.aPIURL + this.controller + '/GetByNameAsync';
        const formUpload: FormData = new FormData();
        formUpload.append('data', JSON.stringify(this.baseParameter));
        return this.httpClient.post(url, formUpload);
    }
    GetByCode() {
        let url = this.aPIURL + this.controller + '/GetByCode';
        const formUpload: FormData = new FormData();
        formUpload.append('data', JSON.stringify(this.baseParameter));
        return this.httpClient.post(url, formUpload);
    }
    GetByCodeAsync() {
        let url = this.aPIURL + this.controller + '/GetByCodeAsync';
        const formUpload: FormData = new FormData();
        formUpload.append('data', JSON.stringify(this.baseParameter));
        return this.httpClient.post(url, formUpload);
    }
    GetAllToList() {
        let url = this.aPIURL + this.controller + '/GetAllToList';
        const formUpload: FormData = new FormData();
        return this.httpClient.post(url, formUpload);
    }
    GetAllToListAsync() {
        let url = this.aPIURL + this.controller + '/GetAllToListAsync';
        const formUpload: FormData = new FormData();
        return this.httpClient.post(url, formUpload);
    }
    GetByIDToList() {
        let url = this.aPIURL + this.controller + '/GetByIDToList';
        const formUpload: FormData = new FormData();
        formUpload.append('data', JSON.stringify(this.baseParameter));
        return this.httpClient.post(url, formUpload);
    }
    GetByIDToListAsync() {
        let url = this.aPIURL + this.controller + '/GetByIDToListAsync';
        const formUpload: FormData = new FormData();
        formUpload.append('data', JSON.stringify(this.baseParameter));
        return this.httpClient.post(url, formUpload);
    }
    GetByActiveToList() {
        let url = this.aPIURL + this.controller + '/GetByActiveToList';
        const formUpload: FormData = new FormData();
        formUpload.append('data', JSON.stringify(this.baseParameter));
        return this.httpClient.post(url, formUpload);
    }
    GetByActiveToListAsync() {
        let url = this.aPIURL + this.controller + '/GetByActiveToListAsync';
        const formUpload: FormData = new FormData();
        formUpload.append('data', JSON.stringify(this.baseParameter));
        return this.httpClient.post(url, formUpload);
    }
    GetByParentIDToList() {
        let url = this.aPIURL + this.controller + '/GetByParentIDToList';
        const formUpload: FormData = new FormData();
        formUpload.append('data', JSON.stringify(this.baseParameter));
        return this.httpClient.post(url, formUpload);
    }
    GetByParentIDToListAsync() {
        let url = this.aPIURL + this.controller + '/GetByParentIDToListAsync';
        const formUpload: FormData = new FormData();
        formUpload.append('data', JSON.stringify(this.baseParameter));
        return this.httpClient.post(url, formUpload);
    }
    GetByParentIDAndActiveToList() {
        let url = this.aPIURL + this.controller + '/GetByParentIDAndActiveToList';
        const formUpload: FormData = new FormData();
        formUpload.append('data', JSON.stringify(this.baseParameter));
        return this.httpClient.post(url, formUpload);
    }
    GetByParentIDAndActiveToListAsync() {
        let url = this.aPIURL + this.controller + '/GetByParentIDAndActiveToListAsync';
        const formUpload: FormData = new FormData();
        formUpload.append('data', JSON.stringify(this.baseParameter));
        return this.httpClient.post(url, formUpload);
    }
    GetByParentIDAndCodeToList() {
        let url = this.aPIURL + this.controller + '/GetByParentIDAndCodeToList';
        const formUpload: FormData = new FormData();
        formUpload.append('data', JSON.stringify(this.baseParameter));
        return this.httpClient.post(url, formUpload);
    }
    GetByParentIDAndCodeToListAsync() {
        let url = this.aPIURL + this.controller + '/GetByParentIDAndCodeToListAsync';
        const formUpload: FormData = new FormData();
        formUpload.append('data', JSON.stringify(this.baseParameter));
        return this.httpClient.post(url, formUpload);
    }
    GetByParentIDAndCodeAndActiveToList() {
        let url = this.aPIURL + this.controller + '/GetByParentIDAndCodeAndActiveToList';
        const formUpload: FormData = new FormData();
        formUpload.append('data', JSON.stringify(this.baseParameter));
        return this.httpClient.post(url, formUpload);
    }
    GetByParentIDAndCodeAndActiveToListAsync() {
        let url = this.aPIURL + this.controller + '/GetByParentIDAndCodeAndActiveToListAsync';
        const formUpload: FormData = new FormData();
        formUpload.append('data', JSON.stringify(this.baseParameter));
        return this.httpClient.post(url, formUpload);
    }
    GetByLastUpdatedMembershipIDToList() {
        let url = this.aPIURL + this.controller + '/GetByLastUpdatedMembershipIDToList';
        const formUpload: FormData = new FormData();
        formUpload.append('data', JSON.stringify(this.baseParameter));
        return this.httpClient.post(url, formUpload);
    }
    GetByLastUpdatedMembershipIDToListAsync(parentID: number) {
        let url = this.aPIURL + this.controller + '/GetByLastUpdatedMembershipIDToListAsync';
        const formUpload: FormData = new FormData();
        formUpload.append('data', JSON.stringify(parentID));
        return this.httpClient.post(url, formUpload);
    }
    GetByLastUpdatedMembershipIDAndActiveToList() {
        let url = this.aPIURL + this.controller + '/GetByLastUpdatedMembershipIDAndActiveToList';
        const formUpload: FormData = new FormData();
        formUpload.append('data', JSON.stringify(this.baseParameter));
        return this.httpClient.post(url, formUpload);
    }
    GetByLastUpdatedMembershipIDAndActiveToListAsync() {
        let url = this.aPIURL + this.controller + '/GetByLastUpdatedMembershipIDAndActiveToListAsync';
        const formUpload: FormData = new FormData();
        formUpload.append('data', JSON.stringify(this.baseParameter));
        return this.httpClient.post(url, formUpload);
    }
    GetBySearchStringToList() {
        let url = this.aPIURL + this.controller + '/GetBySearchStringToList';
        const formUpload: FormData = new FormData();
        formUpload.append('data', JSON.stringify(this.baseParameter));
        return this.httpClient.post(url, formUpload);
    }
    GetBySearchStringToListAsync() {
        let url = this.aPIURL + this.controller + '/GetBySearchStringToListAsync';
        const formUpload: FormData = new FormData();
        formUpload.append('data', JSON.stringify(this.baseParameter));
        return this.httpClient.post(url, formUpload);
    }
    GetByPageAndPageSizeToList() {
        let url = this.aPIURL + this.controller + '/GetByPageAndPageSizeToList';
        const formUpload: FormData = new FormData();
        formUpload.append('data', JSON.stringify(this.baseParameter));
        return this.httpClient.post(url, formUpload);
    }
    GetByPageAndPageSizeToListAsync() {
        let url = this.aPIURL + this.controller + '/GetByPageAndPageSizeToListAsync';
        const formUpload: FormData = new FormData();
        formUpload.append('data', JSON.stringify(this.baseParameter));
        return this.httpClient.post(url, formUpload);
    }
    GetByIDString() {
        let url = this.aPIURL + this.controller + '/GetByIDString';
        const formUpload: FormData = new FormData();
        formUpload.append('data', JSON.stringify(this.baseParameter));
        return this.httpClient.post(url, formUpload);
    }
    GetByIDStringAsync() {
        let url = this.aPIURL + this.controller + '/GetByIDStringAsync';
        const formUpload: FormData = new FormData();
        formUpload.append('data', JSON.stringify(this.baseParameter));
        return this.httpClient.post(url, formUpload);
    }
    SaveList(list: Base[]) {
        let url = this.aPIURL + this.controller + '/SaveList';
        const formUpload: FormData = new FormData();
        formUpload.append('data', JSON.stringify(list));
        return this.httpClient.post(url, formUpload);
    }
    SaveListAsync(list: Base[]) {
        let url = this.aPIURL + this.controller + '/SaveListAsync';
        const formUpload: FormData = new FormData();
        formUpload.append('data', JSON.stringify(list));
        return this.httpClient.post(url, formUpload);
    }
    GetAllAndEmptyToList() {
        let url = this.aPIURL + this.controller + '/GetAllAndEmptyToList';
        const formUpload: FormData = new FormData();
        return this.httpClient.post(url, formUpload);
    }
    GetAllAndEmptyToListAsync() {
        let url = this.aPIURL + this.controller + '/GetAllAndEmptyToListAsync';
        const formUpload: FormData = new FormData();
        return this.httpClient.post(url, formUpload);
    }
    GetByParentIDAndEmptyToList() {
        let url = this.aPIURL + this.controller + '/GetByParentIDAndEmptyToList';
        const formUpload: FormData = new FormData();
        formUpload.append('data', JSON.stringify(this.baseParameter));
        return this.httpClient.post(url, formUpload);
    }
    GetByParentIDAndEmptyToListAsync() {
        let url = this.aPIURL + this.controller + '/GetByParentIDAndEmptyToListAsync';
        const formUpload: FormData = new FormData();
        formUpload.append('data', JSON.stringify(this.baseParameter));
        return this.httpClient.post(url, formUpload);
    }
    GetByParentIDAndActiveAndEmptyToList() {
        let url = this.aPIURL + this.controller + '/GetByParentIDAndActiveAndEmptyToList';
        const formUpload: FormData = new FormData();
        formUpload.append('data', JSON.stringify(this.baseParameter));
        return this.httpClient.post(url, formUpload);
    }
    GetByParentIDAndActiveAndEmptyToListAsync() {
        let url = this.aPIURL + this.controller + '/GetByParentIDAndActiveAndEmptyToListAsync';
        const formUpload: FormData = new FormData();
        formUpload.append('data', JSON.stringify(this.baseParameter));
        return this.httpClient.post(url, formUpload);
    }
    GetByLastUpdatedMembershipIDAndEmptyToList() {
        let url = this.aPIURL + this.controller + '/GetByLastUpdatedMembershipIDAndEmptyToList';
        const formUpload: FormData = new FormData();
        formUpload.append('data', JSON.stringify(this.baseParameter));
        return this.httpClient.post(url, formUpload);
    }
    GetByLastUpdatedMembershipIDAndEmptyToListAsync() {
        let url = this.aPIURL + this.controller + '/GetByLastUpdatedMembershipIDAndEmptyToListAsync';
        const formUpload: FormData = new FormData();
        formUpload.append('data', JSON.stringify(this.baseParameter));
        return this.httpClient.post(url, formUpload);
    }
    GetBySearchStringAndEmptyToList() {
        let url = this.aPIURL + this.controller + '/GetBySearchStringAndEmptyToList';
        const formUpload: FormData = new FormData();
        formUpload.append('data', JSON.stringify(this.baseParameter));
        return this.httpClient.post(url, formUpload);
    }
    GetBySearchStringAndEmptyToListAsync() {
        let url = this.aPIURL + this.controller + '/GetBySearchStringAndEmptyToListAsync';
        const formUpload: FormData = new FormData();
        formUpload.append('data', JSON.stringify(this.baseParameter));
        return this.httpClient.post(url, formUpload);
    }
    SaveAndUploadFile() {
        let url = this.aPIURL + this.controller + '/SaveAndUploadFile';
        const formUpload: FormData = new FormData();
        formUpload.append('data', JSON.stringify(this.formData));
        if (this.fileToUpload) {
            if (this.fileToUpload.length > 0) {
                for (var i = 0; i < this.fileToUpload.length; i++) {
                    formUpload.append('file[]', this.fileToUpload[i]);
                }
            }
        }
        return this.httpClient.post(url, formUpload);
    }
    SaveAndUploadFileAsync() {
        let url = this.aPIURL + this.controller + '/SaveAndUploadFileAsync';
        const formUpload: FormData = new FormData();
        formUpload.append('data', JSON.stringify(this.formData));
        if (this.fileToUpload) {
            if (this.fileToUpload.length > 0) {
                for (var i = 0; i < this.fileToUpload.length; i++) {
                    formUpload.append('file[]', this.fileToUpload[i]);
                }
            }
        }
        return this.httpClient.post(url, formUpload);
    }
    SaveAndUploadFiles() {
        let url = this.aPIURL + this.controller + '/SaveAndUploadFiles';
        const formUpload: FormData = new FormData();
        formUpload.append('data', JSON.stringify(this.formData));
        if (this.fileToUpload) {
            if (this.fileToUpload.length > 0) {
                for (var i = 0; i < this.fileToUpload.length; i++) {
                    formUpload.append('file[]', this.fileToUpload[i]);
                }
            }
        }
        return this.httpClient.post(url, formUpload);
    }
    SaveAndUploadFilesAsync() {
        let url = this.aPIURL + this.controller + '/SaveAndUploadFilesAsync';
        const formUpload: FormData = new FormData();
        formUpload.append('data', JSON.stringify(this.formData));
        if (this.fileToUpload) {
            if (this.fileToUpload.length > 0) {
                for (var i = 0; i < this.fileToUpload.length; i++) {
                    formUpload.append('file[]', this.fileToUpload[i]);
                }
            }
        }
        return this.httpClient.post(url, formUpload);
    }

}

