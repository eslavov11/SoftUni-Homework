#
# Generated Makefile - do not edit!
#
# Edit the Makefile in the project folder instead (../Makefile). Each target
# has a -pre and a -post target defined where you can add customized code.
#
# This makefile implements configuration specific macros and targets.


# Environment
MKDIR=mkdir
CP=cp
GREP=grep
NM=nm
CCADMIN=CCadmin
RANLIB=ranlib
CC=gcc
CCC=g++
CXX=g++
FC=gfortran
AS=as

# Macros
CND_PLATFORM=MinGW-Windows
CND_DLIB_EXT=dll
CND_CONF=Debug
CND_DISTDIR=dist
CND_BUILDDIR=build

# Include project Makefile
include Makefile

# Object Directory
OBJECTDIR=${CND_BUILDDIR}/${CND_CONF}/${CND_PLATFORM}

# Object Files
OBJECTFILES= \
	${OBJECTDIR}/BankAccountData.o \
	${OBJECTDIR}/DeclareVariables.o \
	${OBJECTDIR}/EmployeeData.o \
	${OBJECTDIR}/ExchangeVariableValues.o \
	${OBJECTDIR}/FloatOrDouble.o \
	${OBJECTDIR}/Gender.o \
	${OBJECTDIR}/Names.o \
	${OBJECTDIR}/PrintTheAsciiTable.o \
	${OBJECTDIR}/QuotesInString.o \
	${OBJECTDIR}/VariableInHexademicalFormat.o


# C Compiler Flags
CFLAGS=

# CC Compiler Flags
CCFLAGS=
CXXFLAGS=

# Fortran Compiler Flags
FFLAGS=

# Assembler Flags
ASFLAGS=

# Link Libraries and Options
LDLIBSOPTIONS=

# Build Targets
.build-conf: ${BUILD_SUBPROJECTS}
	"${MAKE}"  -f nbproject/Makefile-${CND_CONF}.mk ${CND_DISTDIR}/${CND_CONF}/${CND_PLATFORM}/homework_2_c_data_types.exe

${CND_DISTDIR}/${CND_CONF}/${CND_PLATFORM}/homework_2_c_data_types.exe: ${OBJECTFILES}
	${MKDIR} -p ${CND_DISTDIR}/${CND_CONF}/${CND_PLATFORM}
	${LINK.c} -o ${CND_DISTDIR}/${CND_CONF}/${CND_PLATFORM}/homework_2_c_data_types ${OBJECTFILES} ${LDLIBSOPTIONS}

${OBJECTDIR}/BankAccountData.o: BankAccountData.c 
	${MKDIR} -p ${OBJECTDIR}
	${RM} "$@.d"
	$(COMPILE.c) -g -MMD -MP -MF "$@.d" -o ${OBJECTDIR}/BankAccountData.o BankAccountData.c

${OBJECTDIR}/DeclareVariables.o: DeclareVariables.c 
	${MKDIR} -p ${OBJECTDIR}
	${RM} "$@.d"
	$(COMPILE.c) -g -MMD -MP -MF "$@.d" -o ${OBJECTDIR}/DeclareVariables.o DeclareVariables.c

${OBJECTDIR}/EmployeeData.o: EmployeeData.c 
	${MKDIR} -p ${OBJECTDIR}
	${RM} "$@.d"
	$(COMPILE.c) -g -MMD -MP -MF "$@.d" -o ${OBJECTDIR}/EmployeeData.o EmployeeData.c

${OBJECTDIR}/ExchangeVariableValues.o: ExchangeVariableValues.c 
	${MKDIR} -p ${OBJECTDIR}
	${RM} "$@.d"
	$(COMPILE.c) -g -MMD -MP -MF "$@.d" -o ${OBJECTDIR}/ExchangeVariableValues.o ExchangeVariableValues.c

${OBJECTDIR}/FloatOrDouble.o: FloatOrDouble.c 
	${MKDIR} -p ${OBJECTDIR}
	${RM} "$@.d"
	$(COMPILE.c) -g -MMD -MP -MF "$@.d" -o ${OBJECTDIR}/FloatOrDouble.o FloatOrDouble.c

${OBJECTDIR}/Gender.o: Gender.c 
	${MKDIR} -p ${OBJECTDIR}
	${RM} "$@.d"
	$(COMPILE.c) -g -MMD -MP -MF "$@.d" -o ${OBJECTDIR}/Gender.o Gender.c

${OBJECTDIR}/Names.o: Names.c 
	${MKDIR} -p ${OBJECTDIR}
	${RM} "$@.d"
	$(COMPILE.c) -g -MMD -MP -MF "$@.d" -o ${OBJECTDIR}/Names.o Names.c

${OBJECTDIR}/PrintTheAsciiTable.o: PrintTheAsciiTable.c 
	${MKDIR} -p ${OBJECTDIR}
	${RM} "$@.d"
	$(COMPILE.c) -g -MMD -MP -MF "$@.d" -o ${OBJECTDIR}/PrintTheAsciiTable.o PrintTheAsciiTable.c

${OBJECTDIR}/QuotesInString.o: QuotesInString.c 
	${MKDIR} -p ${OBJECTDIR}
	${RM} "$@.d"
	$(COMPILE.c) -g -MMD -MP -MF "$@.d" -o ${OBJECTDIR}/QuotesInString.o QuotesInString.c

${OBJECTDIR}/VariableInHexademicalFormat.o: VariableInHexademicalFormat.c 
	${MKDIR} -p ${OBJECTDIR}
	${RM} "$@.d"
	$(COMPILE.c) -g -MMD -MP -MF "$@.d" -o ${OBJECTDIR}/VariableInHexademicalFormat.o VariableInHexademicalFormat.c

# Subprojects
.build-subprojects:

# Clean Targets
.clean-conf: ${CLEAN_SUBPROJECTS}
	${RM} -r ${CND_BUILDDIR}/${CND_CONF}
	${RM} ${CND_DISTDIR}/${CND_CONF}/${CND_PLATFORM}/homework_2_c_data_types.exe

# Subprojects
.clean-subprojects:

# Enable dependency checking
.dep.inc: .depcheck-impl

include .dep.inc
