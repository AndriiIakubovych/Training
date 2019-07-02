﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WebClient.ServiceReference {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="Note", Namespace="http://schemas.datacontract.org/2004/07/WebService")]
    [System.SerializableAttribute()]
    public partial class Note : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.DateTime BeginningTimeField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string DescriptionField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private bool DoneField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.DateTime EndTimeField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int NoteIdField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string NoteNameField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.DateTime BeginningTime {
            get {
                return this.BeginningTimeField;
            }
            set {
                if ((this.BeginningTimeField.Equals(value) != true)) {
                    this.BeginningTimeField = value;
                    this.RaisePropertyChanged("BeginningTime");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Description {
            get {
                return this.DescriptionField;
            }
            set {
                if ((object.ReferenceEquals(this.DescriptionField, value) != true)) {
                    this.DescriptionField = value;
                    this.RaisePropertyChanged("Description");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public bool Done {
            get {
                return this.DoneField;
            }
            set {
                if ((this.DoneField.Equals(value) != true)) {
                    this.DoneField = value;
                    this.RaisePropertyChanged("Done");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.DateTime EndTime {
            get {
                return this.EndTimeField;
            }
            set {
                if ((this.EndTimeField.Equals(value) != true)) {
                    this.EndTimeField = value;
                    this.RaisePropertyChanged("EndTime");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int NoteId {
            get {
                return this.NoteIdField;
            }
            set {
                if ((this.NoteIdField.Equals(value) != true)) {
                    this.NoteIdField = value;
                    this.RaisePropertyChanged("NoteId");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string NoteName {
            get {
                return this.NoteNameField;
            }
            set {
                if ((object.ReferenceEquals(this.NoteNameField, value) != true)) {
                    this.NoteNameField = value;
                    this.RaisePropertyChanged("NoteName");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="ServiceReference.IService")]
    public interface IService {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/GetNotes", ReplyAction="http://tempuri.org/IService/GetNotesResponse")]
        WebClient.ServiceReference.Note[] GetNotes();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/GetNotes", ReplyAction="http://tempuri.org/IService/GetNotesResponse")]
        System.Threading.Tasks.Task<WebClient.ServiceReference.Note[]> GetNotesAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/AddNote", ReplyAction="http://tempuri.org/IService/AddNoteResponse")]
        int AddNote(string noteName, System.DateTime beginningDate, System.DateTime endDate, string description);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/AddNote", ReplyAction="http://tempuri.org/IService/AddNoteResponse")]
        System.Threading.Tasks.Task<int> AddNoteAsync(string noteName, System.DateTime beginningDate, System.DateTime endDate, string description);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/EditNote", ReplyAction="http://tempuri.org/IService/EditNoteResponse")]
        void EditNote(int noteId, string noteName, System.DateTime beginningDate, System.DateTime endDate, string description);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/EditNote", ReplyAction="http://tempuri.org/IService/EditNoteResponse")]
        System.Threading.Tasks.Task EditNoteAsync(int noteId, string noteName, System.DateTime beginningDate, System.DateTime endDate, string description);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/ChangeNoteState", ReplyAction="http://tempuri.org/IService/ChangeNoteStateResponse")]
        void ChangeNoteState(int noteId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/ChangeNoteState", ReplyAction="http://tempuri.org/IService/ChangeNoteStateResponse")]
        System.Threading.Tasks.Task ChangeNoteStateAsync(int noteId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/DeleteNote", ReplyAction="http://tempuri.org/IService/DeleteNoteResponse")]
        void DeleteNote(int noteId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/DeleteNote", ReplyAction="http://tempuri.org/IService/DeleteNoteResponse")]
        System.Threading.Tasks.Task DeleteNoteAsync(int noteId);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IServiceChannel : WebClient.ServiceReference.IService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class ServiceClient : System.ServiceModel.ClientBase<WebClient.ServiceReference.IService>, WebClient.ServiceReference.IService {
        
        public ServiceClient() {
        }
        
        public ServiceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public ServiceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public ServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public ServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public WebClient.ServiceReference.Note[] GetNotes() {
            return base.Channel.GetNotes();
        }
        
        public System.Threading.Tasks.Task<WebClient.ServiceReference.Note[]> GetNotesAsync() {
            return base.Channel.GetNotesAsync();
        }
        
        public int AddNote(string noteName, System.DateTime beginningDate, System.DateTime endDate, string description) {
            return base.Channel.AddNote(noteName, beginningDate, endDate, description);
        }
        
        public System.Threading.Tasks.Task<int> AddNoteAsync(string noteName, System.DateTime beginningDate, System.DateTime endDate, string description) {
            return base.Channel.AddNoteAsync(noteName, beginningDate, endDate, description);
        }
        
        public void EditNote(int noteId, string noteName, System.DateTime beginningDate, System.DateTime endDate, string description) {
            base.Channel.EditNote(noteId, noteName, beginningDate, endDate, description);
        }
        
        public System.Threading.Tasks.Task EditNoteAsync(int noteId, string noteName, System.DateTime beginningDate, System.DateTime endDate, string description) {
            return base.Channel.EditNoteAsync(noteId, noteName, beginningDate, endDate, description);
        }
        
        public void ChangeNoteState(int noteId) {
            base.Channel.ChangeNoteState(noteId);
        }
        
        public System.Threading.Tasks.Task ChangeNoteStateAsync(int noteId) {
            return base.Channel.ChangeNoteStateAsync(noteId);
        }
        
        public void DeleteNote(int noteId) {
            base.Channel.DeleteNote(noteId);
        }
        
        public System.Threading.Tasks.Task DeleteNoteAsync(int noteId) {
            return base.Channel.DeleteNoteAsync(noteId);
        }
    }
}
