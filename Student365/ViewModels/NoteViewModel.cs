﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using Student365.Commands;
using Student365.Models;
using Student365.Models.Repositories;

namespace Student365.ViewModels
{
    internal class NoteViewModel : BaseViewModel, IDataErrorInfo
    {
        private Note _selectedNote;

        public Note SelectedNote
        {
            get => _selectedNote;
            set
            {
                _selectedNote = value;
                if (!(_selectedNote is null))
                {
                    _text = _selectedNote.Text;
                    _selectedName = SelectedNote.Header;
                    OnPropertyChanged(nameof(SelectedName));
                    OnPropertyChanged(nameof(SelectedNote));
                    OnPropertyChanged(nameof(Text));
                }
                else
                {
                    _text = "";
                    _selectedName = "";
                    OnPropertyChanged(nameof(SelectedName));
                    OnPropertyChanged(nameof(SelectedNote));
                    OnPropertyChanged(nameof(Text));
                }
            }
        }

        private string _newNoteHeader;

        public string NewNoteHeader
        {
            get => _newNoteHeader;
            set
            {
                _newNoteHeader = value;
                OnPropertyChanged(nameof(NewNoteHeader));
            }
        }

        private string _text;

        public string Text
        {
            get
            {
                return _text;
            }
            set
            {
                _text = value;
                OnPropertyChanged(nameof(Text));
            }
        }

        private string _selectedName;

        public string SelectedName
        {
            get
            {
                return _selectedName;
            }
            set
            {
                _selectedName = value;
                OnPropertyChanged(nameof(SelectedName));
            }
        }

        private ObservableCollection<Note> _notes;

        public ObservableCollection<Note> Notes
        {
            get
            {
                return _notes;
            }
            set
            {
                _notes = value;
                OnPropertyChanged(nameof(Notes));
            }
        }

        public ICommand SubmitCommand { get; }
        public ICommand AddNoteCommand { get; }
        public ICommand DeleteNoteCommand { get; }

        string IDataErrorInfo.Error
        {
            get { return null; }
        }

        public string this[string columnName]
        {
            get
            {
                string error = null;

                switch (columnName)
                {
                    case nameof(NewNoteHeader):
                        if (string.IsNullOrEmpty(NewNoteHeader))
                        {
                            error = "Заголовок не может быть пустым";
                            break;
                        }
                        if (NewNoteHeader?.Length > 50)
                        {
                            error = "Заголовок не может быть длиннее 50 символов";
                        }

                        break;

                    case nameof(Text):
                        if (string.IsNullOrEmpty(Text))
                        {
                            error = "Текст не может быть пустым";
                            break;
                        }
                        if (Text?.Length > 1000)
                        {
                            error = "Текст не может быть длиннее 1000 символов";
                        }

                        break;
                }

                return error;
            }
        }

        public NoteViewModel()
        {
            _notes = UnitOfWork.NotesRepository.GetAllNotesByUser(UnitOfWork.CurrentsUser.UserName);
            SubmitCommand = new SubmitNoteCommand(this);
            AddNoteCommand = new AddNoteCommand(this);
            DeleteNoteCommand = new DeleteNoteCommand(this);
        }
    }
}