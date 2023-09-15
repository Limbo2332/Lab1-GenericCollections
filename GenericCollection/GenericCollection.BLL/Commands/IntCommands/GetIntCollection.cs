﻿using GenericCollection.BLL.Interfaces;
using GenericCollection.BLL.Interfaces.Abstract;
using GenericCollection.DAL.Repositories.Interfaces;

namespace GenericCollection.BLL.Commands.IntCommands
{
    public class GetIntCollection : BaseIntCommand
    {
        public GetIntCollection(ICheckData checkData, IWriter writer, IIntLinkedListRepository repository) 
            : base(checkData, writer, repository)
        {
        }

        public override string Name => "Get items of int collection";

        public override void Execute()
        {
            var collection = _repository.GetCollection();

            _writer.WriteMyLinkedList(collection);
        }
    }
}